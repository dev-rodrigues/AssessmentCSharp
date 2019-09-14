using LibApp.Service.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    class Program {

        private static IDocumento DocumentoService = ServiceLocator.GetInstanceOf<DocumentoImpl>();

        static void Main(string[] args) {

            Console.WriteLine(DocumentoService.HaveDirectory());


            Console.ReadKey();

        }
    }
}
