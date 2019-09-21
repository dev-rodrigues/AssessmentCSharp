using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.DAO.Amgio {
    public interface IAmigo {

        int getNextId();

        void CadastrarAmigo(Amigo amigo, Usuario usuarioLogado);

        List<Amigo> BuscarAmigos(string PalavraChave, Usuario IdUsuario);

    }
}
