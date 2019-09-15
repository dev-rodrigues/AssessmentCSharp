using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Model {
    public class Usuario {

        public String Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public String Senha { get; set; }

        public Usuario() {

        }

        public Usuario(String Id, String Nome, String SobreNome, String Email, DateTime Nascimento, String Senha) {
            this.Id = Id;
            this.Nome = Nome;
            this.SobreNome = SobreNome;
            this.Email = Email;
            this.Nascimento = Nascimento;
            this.Senha = Senha;
        }
    }
}