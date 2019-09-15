using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service {
    interface IUsuario {

        Model.Usuario Cadastrar(String nome, String SobreNome, String Email, DateTime DataNascimento, String Senha);

        Model.Usuario Logar(String Email, String Senha);
    }
}