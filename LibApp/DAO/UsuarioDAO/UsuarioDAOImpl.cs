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

        // registra um usuario
        void IUsuarioDAO.Register(Usuario usuario) {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine(ReturnLineObj(usuario));
                Console.WriteLine("Usuario cadastrado com sucesso!");
            }
        }

        // Retorna o proximo Id valido;
        public int getNextId() {
            return getUsuarios().Count() + 1;
        }

        // Busca um usuario
        Usuario IUsuarioDAO.Find(string Email, string Senha) {
            var file = getFile();

            List<Usuario> UsuariosCadastrados = new List<Usuario>();
            UsuariosCadastrados.AddRange(getUsuarios());

            Usuario usuario = null;
            foreach (Usuario u in UsuariosCadastrados) {
                if (u.Email == Email && u.Senha == Senha) {
                    usuario = u;
                    break;
                }
            }

            if (usuario != null) {
                usuario.Amigos.AddRange(getAmigos(usuario));
            }
            
            file.Close();
            return usuario;
        }

        // Verifica se existe algum usuario cadastrado
        bool IUsuarioDAO.HasRegisteredUser() {
            List<Usuario> Usuarios = getUsuarios();
            if (Usuarios.Count() == 0) {
                return false;
            }
            return true;
        }

        // Deve retornar Stream IO do arquivo principal
        private System.IO.StreamReader getFile() {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            return file;
        }

        // Deve retornar os amigos do usuario logado
        private List<Model.Amigo> getAmigos(Usuario usuario) {
            string line;
            List<Model.Amigo> amigosEncontrados = new List<Model.Amigo>();            
            var file = getFile();
    
            while ((line = file.ReadLine()) != null) {
                string[] fracao = line.Split(',');

                for(int i = 0; i<fracao.Length; i++) {                    
                    if (i == 0 && fracao[i].Contains("a_") && fracao[4].Equals(usuario.Id)) {
                        Model.Amigo localizado = new Model.Amigo(fracao[0], fracao[1], fracao[2], Convert.ToDateTime(fracao[3]), fracao[4]);
                        amigosEncontrados.Add(localizado);
                        break;
                    }
                }
            }
            file.Close();
            return amigosEncontrados;
        }

        // Retorna uma lista de usuarios
        private List<Usuario> getUsuarios() {
            string line;
            var Usuarios = new List<Usuario>();
            var arquivo = getFile();

            while ((line = arquivo.ReadLine()) != null) {
                String[] fracoes = line.Split(',');

                for (int i = 0; i < fracoes.Length; i++) {
                    if (i == 0 && fracoes[i].Contains("u_")) {
                        Usuario u = new Usuario(fracoes[0], fracoes[1], fracoes[2], fracoes[3], Convert.ToDateTime(fracoes[4]), fracoes[5].ToString().Replace(";", ""));
                        Usuarios.Add(u);
                    }
                }
            }
            arquivo.Close();
            return Usuarios;
        }

        // Retorna uma string com os dados do obj para serem gravados
        private string ReturnLineObj(Usuario usuario) {
            return $"{usuario.Id},{usuario.Nome},{usuario.SobreNome},{usuario.Email},{usuario.Nascimento.ToString()},{usuario.Senha}";
        }

        // retorna o path do local onde o arquivo está guardado
        private string ReturnPath(String DirectoryName, String FileName) {
            return System.IO.Path.Combine(DirectoryName, FileName);
        }
    }
}