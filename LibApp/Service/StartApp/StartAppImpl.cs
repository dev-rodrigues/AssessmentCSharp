using LibApp.Service.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.StartApp {
    public class StartAppImpl : IStartApp {

        private static IDocumento DocumentoService = ServiceLab.GetInstanceOf<DocumentoImpl>();
        const string DIRECTORY_NAME = "assessment_carlos_henrique";
        const string FILE_DB_NAME = "db_file_name_carlos_henrique";

        bool IStartApp.start() {

            while (!DocumentoService.HaveDirectory(DIRECTORY_NAME)) {
                DocumentoService.CreateDirectory(DIRECTORY_NAME);
            }

            return false;
        }
    }
}
