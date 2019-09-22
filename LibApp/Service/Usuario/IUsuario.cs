using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service {
    public interface IUsuario {

        Model.Usuario CadastrarUsuario(string[] vetor);
        
        Model.Amigo CadastrarAmigo(string[] vetor, Model.Usuario UsuarioLogado);

        List<Model.Amigo> BuscarAmigo(string PalavraChave, Model.Usuario UsuarioLogado);

        List<Model.Amigo> AllAmigos(Model.Usuario UsuarioLogado);

        Model.Usuario Logar(string[] vetor);

        bool HasRegisteredUser();
    }
}