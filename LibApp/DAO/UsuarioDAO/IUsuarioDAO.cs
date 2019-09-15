using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.DAO.UsuarioDAO {
    public interface IUsuarioDAO {

        void Register(Usuario usuario);

        int getNextId();

        Model.Usuario Find(string nome, string senha);

        Boolean HasRegisteredUser();
    }
}