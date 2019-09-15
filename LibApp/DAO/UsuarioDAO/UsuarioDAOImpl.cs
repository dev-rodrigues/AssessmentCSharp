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

        void IUsuarioDAO.cadastrar(Usuario usuario) {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine(ReturnLineObj(usuario));
            }
        }

        private string ReturnLineObj(Usuario usuario) {
            return $"{usuario.Id},{usuario.Nome},{usuario.SobreNome},{usuario.Nascimento.ToString()},{usuario.Senha}";
        }

        private string ReturnPath(String DirectoryName, String FileName) {
            return System.IO.Path.Combine(DirectoryName, FileName);
        }
    }
}