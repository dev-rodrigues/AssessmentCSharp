using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Model {
    class Cliente {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTime Nascimento { get; set; }
    }
}
