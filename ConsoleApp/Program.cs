using LibApp.Service.Documento;
using LibApp.Service.StartApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    class Program {

        private static IDocumento DocumentoService = ServiceLocator.GetInstanceOf<DocumentoImpl>();
        private static IStartApp StartService = ServiceLocator.GetInstanceOf<StartAppImpl>();

        static void Main(string[] args) {


            StartService.start();

            Console.ReadKey();

        }
    }
}
