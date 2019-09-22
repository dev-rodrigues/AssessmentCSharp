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
            int dias = 0;
            int day = (Int32)this.Nascimento.Day;
            int month = (Int32)this.Nascimento.Month;

            if (AniversarioJaPassou()) {
                DateTime newDate = new DateTime(DateTime.Today.Year + 1, month, day);
                dias = (Int32)newDate.Subtract(DateTime.Today).TotalDays;
            } else {
                DateTime newDate = new DateTime(DateTime.Today.Year, month, day);
                dias = (Int32)newDate.Subtract(DateTime.Today).TotalDays;
            }
            return dias;
        }

        private bool AniversarioJaPassou() {
            int MesAniversario = this.Nascimento.Month;
            int MesAtual = DateTime.Now.Month;

            if (MesAniversario < MesAtual) {
                return true;
            }
            return false;
        }
    }
}