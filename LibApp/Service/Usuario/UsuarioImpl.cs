using LibApp.DAO.Amgio;
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
        private IAmigo AmigoDAO = ServiceLab.GetInstanceOf<AmigoDAOImpl>();


        public Model.Usuario Cadastrar(string[] dadosColetados) {
            //BUSCAR ID válido
            string id = "u_" + UsuarioDAO.getNextId();

            Model.Usuario newObj = new Model.Usuario(id, dadosColetados[0], dadosColetados[1], dadosColetados[2], Convert.ToDateTime(dadosColetados[3]), dadosColetados[4]);

            try {
                UsuarioDAO.Register(newObj);
                return newObj;
            } catch (Exception e) {
                Console.WriteLine("Error ao cadastrar usuario");
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Amigo CadastrarAmigo(string[] dadosColetados, Model.Usuario usuario) {
            //BUSCAR ID válido       
            string id = "a_" + AmigoDAO.getNextId();
            Model.Amigo newAmigo = new Amigo(id, dadosColetados[0], dadosColetados[1], Convert.ToDateTime(dadosColetados[2]), usuario.Id);

            try {
                AmigoDAO.CadastrarAmigo(newAmigo);                
            } catch(Exception e) {
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