using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.DAO.Amigo {
    public interface IAmigo {

        int getNextId();

        void CadastrarAmigo(Model.Amigo amigo, Usuario usuarioLogado);

        List<Model.Amigo> BuscarAmigos(string PalavraChave, Usuario IdUsuario);

        List<Model.Amigo> BuscarAmigos(Usuario usuario);

        bool ExcluirAmigo(Usuario usuario, string PalavraChave);

    }
}
