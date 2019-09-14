using LibApp.Service.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp {
    class ServiceLab {

        private static Dictionary<Type, Type> dependencies = new Dictionary<Type, Type> {
            [typeof(IDocumento)] = typeof(DocumentoImpl)
        };

        internal static T GetInstanceOf<T>() {
            return Activator.CreateInstance<T>();
        }
    }
}
