using LibApp.Model;
using LibApp.DAO.Amigo;
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
            return getAmigos().Count + 1;
        }

        public void CadastrarAmigo(Model.Amigo amigo, Usuario usuarioLogado) {
            string path = ReturnPath();

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine(ReturnLineObj(amigo));
                usuarioLogado.Amigos.Add(amigo);
                Console.WriteLine("Amigo cadastrado");
            }
        }

        // Deve retornar uma lista de amigos
        public List<Model.Amigo> BuscarAmigos(string PalavraChave, Usuario UsuarioLogado) {
            var Amigos = getAmigosAux(PalavraChave, UsuarioLogado);
            return Amigos;
        }

        public List<Model.Amigo> BuscarAmigos(Usuario usuario) {
            return usuario.Amigos;
        }

        public bool ExcluirAmigo(Usuario usuario, string PalavraChave) {
            if (ExcluirAmigoMemoria(usuario, PalavraChave) && ExcluirAmigoDocumento(usuario, PalavraChave)) {
                return true;
            }
            return false;
        }

        private bool ExcluirAmigoDocumento(Usuario Usuario, string PalavraChave) {
            var LinesFile = new List<string>(getLines());
            var newFile = ExcluiPalavraChave(LinesFile, PalavraChave);
            var apagou = false;
            
            try {
                File.WriteAllLines(ReturnPath(), newFile.ToArray());
                apagou = true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }               
            return apagou;
        }
        
        private List<string> ExcluiPalavraChave(List<string> lines, string PalavraChave) {
            var NewLines = new List<string>();
            foreach (var v in lines) {
                if (!v.Contains(PalavraChave)) {
                    NewLines.Add(v);
                }
            }
            return NewLines;
        }

        private List<string> getLines() {
            string line;
            var file = getFile();
            var list = new List<string>();
            while ((line = file.ReadLine()) != null) {
                list.Add(line);
            }
            file.Close();
            return list;
        }

        private bool ExcluirAmigoMemoria(Usuario usuario, string PalavraChave) {
            var i = 0;

            foreach (Model.Amigo a in usuario.Amigos) {
                if (a.Nome.Contains(PalavraChave) || a.SobreNome.Contains(PalavraChave)) {
                    usuario.Amigos.RemoveAt(i);
                    return true;
                }
                i++;
            }
            return false;
        }

        // Deve retornar uma lista de amigos
        private List<Model.Amigo> getAmigos() {
            string line;
            var file = getFile();
            var Amigos = new List<Model.Amigo>();

            while ((line = file.ReadLine()) != null) {
                String[] fracoes = line.Split(',');
                Amigos.AddRange(getAmigosAux(fracoes));
            }
            file.Close();
            return Amigos;
        }

        // Deve retornar uma lista de amigos localizados em funcao da lista de amigos do usuario logado
        private List<Model.Amigo> getAmigosAux(string PalavraChave, Usuario UsuarioLogado) {
            var localizados = new List<Model.Amigo>();

            foreach (Model.Amigo a in UsuarioLogado.Amigos) {
                if (a.Nome.Contains(PalavraChave) || a.SobreNome.Contains(PalavraChave)) {
                    localizados.Add(a);
                }
            }
            return localizados;
        }

        // Deve retornar uma lista de amigos
        private List<Model.Amigo> getAmigosAux(String[] fracoes) {
            List<Model.Amigo> Amigos = new List<Model.Amigo>();
            for (int i = 0; i < fracoes.Length; i++) {
                if (fracoes[i].Contains("a_")) {
                    Model.Amigo a = new Model.Amigo(fracoes[0], fracoes[1], fracoes[2], Convert.ToDateTime(fracoes[3]), fracoes[4]);
                    Amigos.Add(a);
                }
            }
            return Amigos;
        }

        // Deve retornar uma instancia do file io
        private System.IO.StreamReader getFile() {
            string path = ReturnPath();
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            return file;
        }

        private string ReturnPath() {
            return System.IO.Path.Combine(DIRECTORY_NAME, FILE_DB_NAME);
        }

        // Deve retornar a string que será salva no arquivo
        private string ReturnLineObj(Model.Amigo amigo) {
            return $"{amigo.Id},{amigo.Nome},{amigo.SobreNome},{amigo.Nascimento},{amigo.IdUsuario}";
        }
    }
}
