using LibApp.Helper;
using LibApp.Model;
using LibApp.Service;
using LibApp.Service.Documento;
using LibApp.Service.StartApp;
using LibApp.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    class Program {

        private static IDocumento DocumentoService = ServiceLocator.GetInstanceOf<DocumentoImpl>();
        private static IStartApp StartService = ServiceLocator.GetInstanceOf<StartAppImpl>();
        private static IUsuario UsuarioService = ServiceLocator.GetInstanceOf<UsuarioImpl>();

        static void Main(string[] args) {

            Console.WriteLine("########## App running ##########");

            StartService.start();

            if (!UsuarioService.HasRegisteredUser()) {
                string[] dados = Utils.SolicitarDadosCadastrar();
                UsuarioService.Cadastrar(dados);
            } else {
                string[] dados = Utils.SolicitarDadosCadastrar();
                UsuarioService.Cadastrar(dados);
                //string[] dadosLogin = Utils.SolicitarDadosLogar();

                //var u = UsuarioService.Logar(dadosLogin);
                //if (u == null) {
                //    Console.WriteLine("erro ao logar");
                //} else {
                //    Console.WriteLine("logado com sucesso");
                //}
            }

            Console.WriteLine("Aperte uma tecla para continuar...");



            Console.WriteLine("########## App stopping ##########");
            Console.ReadKey();
        }
    }
}