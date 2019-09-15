using System;
using System.Collections.Generic;
using LibApp.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaId.Service {
    class GeneratorId : IGeneratorId {

        const string DIRECTORY_NAME = @"C:\assessment_carlos_henrique";
        const string FILE_DB_NAME = "db_file_name_carlos_henrique.txt";

        public int getIdAmigo() {
            throw new NotImplementedException();
        }

        public int getIdUsuario() {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            return getUsuarios(file).Count + 1;
        }

        private string ReturnPath(String DirectoryName, String FileName) {
            return System.IO.Path.Combine(DirectoryName, FileName);
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
    }
}