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
                System.IO.Directory.CreateDirectory(DirectoryName);
                created = true;
                Console.WriteLine("Diretorio " + DirectoryName + " criado com sucesso");
            } catch (Exception) {
                Console.WriteLine("Erro ao criar diretorio" + DirectoryName);
            }
            return created;
        }

        //  verifica se Diretorio existe em C://
        bool IDocumento.HaveDirectory(String DirectoryName) {
            if (Directory.Exists(DirectoryName)) {
                Console.WriteLine("O Diretorio " + DirectoryName + "Já existe");
                return true;
            }
            Console.WriteLine("O Diretório " + DirectoryName + " não existe no disco C://");
            return false;
        }

        // Verifica se o Arquivo principal existe dentro do diretorio
        bool IDocumento.HavePrincipalFile(String DirectoryName, String FileName) {
            String combined = ReturnPath(DirectoryName, FileName);

            if (!System.IO.File.Exists(combined)) {
                return false;
            }
            return true;
        }

        // Cria o arquivo principal para ser usado com banco de dados
        void IDocumento.CreatePrincipalFile(string DirectoryName, string FileName) {
            String combined = ReturnPath(DirectoryName, FileName);

            using (var fluxoArquivo = System.IO.File.Create(combined)) {
                for (byte i = 0; i < 0; i++) {
                    fluxoArquivo.WriteByte(i);
                }
                Console.WriteLine("Arquivo Principal Criado");
            }
        }

        private string ReturnPath(String DirectoryName, String FileName) {
            return System.IO.Path.Combine(DirectoryName, FileName);
        }
    }
}