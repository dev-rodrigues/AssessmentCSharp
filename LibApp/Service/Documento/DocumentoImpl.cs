using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.Documento {
    public class DocumentoImpl : IDocumento {

        // Cria o Diretorio em Disco C://
        bool IDocumento.CreateDirectory(String DirectoryName) {
            bool created = false;

            try {
                string aux = @"C:\" + DirectoryName;
                System.IO.Directory.CreateDirectory(aux);
                created = true;
                Console.WriteLine("Diretorio " + aux + " criado com sucesso");
            } catch (Exception e) {
                Console.WriteLine("Erro ao criar diretorio 'c://assessment'");
            }
            return created;
        }

        //  verifica se Diretorio existe em C://
        bool IDocumento.HaveDirectory(String DirectoryName) {
            if (Directory.Exists("C://" + DirectoryName)) {
                return true;
            }
            Console.WriteLine("O Diretório " + DirectoryName + " não existe no disco C://");
            return false;
        }

        // Verifica se o Arquivo principal existe dentro do diretorio
        bool IDocumento.HavePrincipalFile() {
            return false;
        }
    }
}
