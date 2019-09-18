using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service {
    public interface IUsuario {

        Model.Usuario Cadastrar(string[] vetor);
        
        Model.Amigo CadastrarAmigo(string[] vetor, Model.Usuario usuario);

        Model.Usuario Logar(string[] vetor);

        bool HasRegisteredUser();
    }
}