using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.Documento {
    public class DocumentoImpl : IDocumento {
        bool IDocumento.HaveDirectory() {
            if (Directory.Exists("C://temp")) {
                return true;
            }
            return false;
        }

        bool IDocumento.HavePrincipalFile() {
            return false;
        }
    }
}
