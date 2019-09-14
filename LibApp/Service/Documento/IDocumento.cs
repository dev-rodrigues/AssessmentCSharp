using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.Documento {
    public interface IDocumento {

        Boolean HaveDirectory(String DirectoryName);

        Boolean CreateDirectory(String DirectoryName);

        Boolean HavePrincipalFile();
    }
}
