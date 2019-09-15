using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibApp.Model;

namespace LibApp.DAO.UsuarioDAO {
    public class UsuarioDAOImpl : IUsuarioDAO {

        const string DIRECTORY_NAME = @"C:\assessment_carlos_henrique";
        const string FILE_DB_NAME = "db_file_name_carlos_henrique.txt";


        void IUsuarioDAO.Register(Usuario usuario) {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine(ReturnLineObj(usuario));
                Console.WriteLine("Usuario cadastrado com sucesso!");
            }
        }

        Usuario IUsuarioDAO.Find(string Email, string Senha) {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            List<Usuario> UsuariosCadastrados = new List<Usuario>();
            UsuariosCadastrados.AddRange(getUsuarios(file));

            Usuario obj = null;
            foreach (Usuario u in UsuariosCadastrados) {
                if (u.Email == Email && u.Senha == Senha) {
                    obj = u;
                    break;
                }
            }
            file.Close();
            return obj;
        }

        bool IUsuarioDAO.HasRegisteredUser() {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            List<Usuario> Usuarios = getUsuarios(file);
            file.Close();
            if (Usuarios.Count() == 0) {
                return false;
            }
            return true;
        }

        private List<Usuario> getUsuarios(System.IO.StreamReader arquivo) {
            int counter = 0;
            string line;
            List<Usuario> Usuarios = new List<Usuario>();

            while ((line = arquivo.ReadLine()) != null) {
                String[] fracoes = line.Split(',');

                for (int i = 0; i < fracoes.Length; i++) {
                    if (fracoes[i].Contains("u_")) {
                        Usuario u = new Usuario(fracoes[0], fracoes[1], fracoes[2], fracoes[3], Convert.ToDateTime(fracoes[4]), fracoes[5].ToString().Replace(";", ""));
                        Usuarios.Add(u);
                    }
                }
                counter++;
            }
            arquivo.Close();
            return Usuarios;
        }

        private string ReturnLineObj(Usuario usuario) {
            return $"{usuario.Id},{usuario.Nome},{usuario.SobreNome},{usuario.Email},{usuario.Nascimento.ToString()},{usuario.Senha}";
        }

        private string ReturnPath(String DirectoryName, String FileName) {
            return System.IO.Path.Combine(DirectoryName, FileName);
        }

    }
}