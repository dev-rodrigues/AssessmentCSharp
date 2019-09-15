using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.DAO.UsuarioDAO {
    public interface IUsuarioDAO {

        void cadastrar(Usuario usuario);

        Model.Usuario buscar(string nome, string senha);
    }
}