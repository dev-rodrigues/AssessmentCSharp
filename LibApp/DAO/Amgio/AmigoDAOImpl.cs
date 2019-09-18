using LibApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.DAO.Amgio {

    public class AmigoDAOImpl : IAmigo {

        const string DIRECTORY_NAME = @"C:\assessment_carlos_henrique";
        const string FILE_DB_NAME = "db_file_name_carlos_henrique.txt";

        int IAmigo.getNextId() {
            return getAmigos(getFile()).Count + 1;
        }

        public void CadastrarAmigo(Amigo amigo) {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine();
                Console.WriteLine("Amigo cadastrado");
            }
        }

        private List<Amigo> getAmigos(System.IO.StreamReader arquivo) {
            string line;

            List<Amigo> Amigos = new List<Amigo>();

            while((line = arquivo.ReadLine()) != null) {
                String[] fracoes = line.Split(',');

                for (int i = 0; i < fracoes.Length; i++) {
                    if (fracoes[i].Contains("a_")) {
                        Amigo a = new Amigo(fracoes[0], fracoes[1], fracoes[2], Convert.ToDateTime(fracoes[3]), fracoes[4]);
                        Amigos.Add(a);
                    }
                }
            }

            return Amigos;
        }

        private System.IO.StreamReader getFile() {
            string path = ReturnPath(DIRECTORY_NAME, FILE_DB_NAME);
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            return file;
        }

        private string ReturnPath(String DirectoryName, String FileName) {
            return System.IO.Path.Combine(DirectoryName, FileName);
        }

        private string ReturnLineObj(Amigo amigo) {
            return $"{amigo.Id},{amigo.Nome},{amigo.SobreNome},,{amigo.Nascimento},{amigo.IdUsuario}";
        }
    }
}
