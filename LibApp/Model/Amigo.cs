using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Model {
    public class Amigo {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTime Nascimento { get; set; }

        public string IdUsuario { get; set; }

        public Amigo() {

        }

        public Amigo(String Id, String Nome, String SobreNome, DateTime Nascimento, String IdUsuario) {
            this.Id = Id;
            this.Nome = Nome;
            this.SobreNome = SobreNome;
            this.Nascimento = Nascimento;
            this.IdUsuario = IdUsuario;
        }

        public int TotalDeDiasProAniversario() {
            int day = (Int32)this.Nascimento.Day;
            int month = (Int32)this.Nascimento.Month;
            DateTime newDate = new DateTime(DateTime.Today.Year, month, day);
            return (Int32)newDate.Subtract(DateTime.Today).TotalDays;
        }
    }
}