using LibApp.Service.Documento;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.StartApp {
    public class StartAppImpl : IStartApp {

        private static IDocumento DocumentoService = ServiceLab.GetInstanceOf<DocumentoImpl>();
        private static IUsuario UsuarioService = ServiceLab.GetInstanceOf<Usuario.UsuarioImpl>();

        const string DIRECTORY_NAME = @"C:\assessment_carlos_henrique";
        const string FILE_DB_NAME = "db_file_name_carlos_henrique.txt";

        public static object UsuarioImpl { get; private set; }

        void IStartApp.start() {
            CriaDiretorioPrincipal();
            criaArquivoPrincipal();

            Console.WriteLine("cadastrando...");
            UsuarioService.Cadastrar("carlos", "santos", new DateTime(1994, 10, 05), "123");
            Console.WriteLine("cadastrado");


            Console.WriteLine("Aperte uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        // deve chamar o serviço e criar o diretorio;
        private void CriaDiretorioPrincipal() {
            while (!DocumentoService.HaveDirectory(DIRECTORY_NAME)) {
                DocumentoService.CreateDirectory(DIRECTORY_NAME);
            }
        }

        // deve chamar o serviço e criar o arquivo principal
        private void criaArquivoPrincipal() {
            while (!DocumentoService.HavePrincipalFile(DIRECTORY_NAME, FILE_DB_NAME)) {
                DocumentoService.CreatePrincipalFile(DIRECTORY_NAME, FILE_DB_NAME);
            }
        }
    }
}