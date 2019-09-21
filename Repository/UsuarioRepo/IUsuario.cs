using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UsuarioRepo {
    public interface IUsuario {

        Object CadastrarUsuario(string[] vetor);

        Object CadastrarAmigo(string[] vetor, Object UsuarioLogado);

        List<Object> BuscarAmigo(string PalavraChave, Object UsuarioLogado);

        Object Logar(string[] vetor);

        bool HasRegisteredUser();
    }
}
