using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Model {
    public class Amigo {

        public string Id { get; set; }

        public String PrimeiroNome { get; set; }

        public String SobreNome { get; set; }

        public DateTime Nascimento { get; set; }
     
        public Amigo() {

        }

        public Amigo(String Id, String PrimeiroNome, String SobreNome, DateTime Nascimento) {
            this.Id = Id;
            this.PrimeiroNome = PrimeiroNome;
            this.SobreNome = SobreNome;
            this.Nascimento = Nascimento;
        }
    }
}