using LibApp.DAO.UsuarioDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Service.Usuario {
    public class UsuarioImpl : IUsuario {

        private IUsuarioDAO UsuarioDAO = ServiceLab.GetInstanceOf<UsuarioDAOImpl>();

        public Model.Usuario Cadastrar(String nome, String SobreNome, String Email, DateTime DataNascimento, String Senha) {
            string id = "u_" + 1;
            Model.Usuario newObj = new Model.Usuario(id, nome, SobreNome, Email, DataNascimento, Senha);

            try {
                UsuarioDAO.cadastrar(newObj);
                return newObj;
            } catch (Exception) {
                Console.WriteLine("Error ao cadastrar usuario");
            }
            return null;
        }

        Model.Usuario IUsuario.Logar(string Email, string Senha) {
            return UsuarioDAO.buscar(Email, Senha);
        }
    }
}
