using LibApp.DAO.UsuarioDAO;
using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.Usuario {
    public class UsuarioImpl : IUsuario {

        private IUsuarioDAO UsuarioDAO = ServiceLab.GetInstanceOf<UsuarioDAOImpl>();

        public Model.Usuario Cadastrar(string[] dadosColetados) {
            string id = "u_" + 1;

            Model.Usuario newObj = new Model.Usuario(id, dadosColetados[0], dadosColetados[1], dadosColetados[2],
                Convert.ToDateTime(dadosColetados[3]), dadosColetados[4]);

            try {
                UsuarioDAO.Register(newObj);
                return newObj;
            } catch (Exception e) {
                Console.WriteLine("Error ao cadastrar usuario");
                Console.WriteLine(e.Message);
            }
            return null;
        }

        bool IUsuario.HasRegisteredUser() {
            return UsuarioDAO.HasRegisteredUser();
        }

        Model.Usuario IUsuario.Logar(string[] dadosColetados) {
            return UsuarioDAO.Find(dadosColetados[0], dadosColetados[1]);
        }
    }
}