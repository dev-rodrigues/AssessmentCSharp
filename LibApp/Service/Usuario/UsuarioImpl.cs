using LibApp.DAO.Amgio;
using LibApp.DAO.UsuarioDAO;
using LibApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.UsuarioRepo;

namespace LibApp.Service.Usuario {
    public class UsuarioImpl : IUsuario {

        private IAmigo AmigoDAO = ServiceLab.GetInstanceOf<AmigoDAOImpl>();
        private IUsuarioDAO UsuarioDAO = ServiceLab.GetInstanceOf<UsuarioDAOImpl>();

        /// <summary>
        /// Deve Cadastrar um novo usuario no sistema
        /// </summary>
        /// <param name="dadosColetados">
        /// Vetor contendo os dados do objeto
        /// </param>
        /// <returns>
        /// Deve retornar um novo usuario
        /// </returns>
        public object CadastrarUsuario(string[] dadosColetados) {
            var id = GerarIdUsuario();
            
            try {
                Model.Usuario NovoUsuario = new Model.Usuario(id, dadosColetados[0], dadosColetados[1], dadosColetados[2], Convert.ToDateTime(dadosColetados[3]), dadosColetados[4]);
                UsuarioDAO.Register(NovoUsuario);
                return NovoUsuario;
            } catch(Exception e) {
                Console.WriteLine("Error ao cadastrar usuario");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            return null;
        }

        /// <summary>
        /// Deve gerar um novo Id válido para o usuario
        /// </summary>
        /// <returns>
        /// String contendo um id pro novo usuario
        /// </returns>
        private string GerarIdUsuario() {
            return $"u_{UsuarioDAO.getNextId()}";
        }

        /// <summary>
        /// Deve Cadastrar um novo amigo no sistema
        /// </summary>
        /// <param name="dadosColetados">
        /// Vetor contendo os dados do objeto
        /// </param>
        /// <param name="UsuarioLogado">
        /// Usuario logado no sistema
        /// </param>
        /// <returns>
        /// Novo amigo cadastrado
        /// </returns>
        public object CadastrarAmigo(string[] dadosColetados, object UsuarioLogado) {
            var id = GerarIdAmigo();
            var usuario = (Model.Usuario)UsuarioLogado;
            
            try {
                Model.Amigo newAmigo = new Amigo(id, dadosColetados[0], dadosColetados[1], Convert.ToDateTime(dadosColetados[2]), usuario.Id);
                AmigoDAO.CadastrarAmigo(newAmigo, usuario);
                return newAmigo;
            } catch (Exception e) {
                Console.WriteLine("Error ao cadastrar usuario");
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Deve gerar um novo Id válido para o amigo
        /// </summary>
        /// <returns>
        /// String contendo um id pro novo amigo
        /// </returns>
        private string GerarIdAmigo() {
            return $"a_{AmigoDAO.getNextId()}";
        }

        /// <summary>
        /// Deve buscar os amigos do usuario logado
        /// </summary>
        /// <param name="PalavraChave">
        /// Nome ou parte do amigo desejado
        /// </param>
        /// <param name="UsuarioLogado">
        /// Instancia do usuario logado
        /// </param>
        /// <returns>
        /// Amigos localizados em função da palavra chave informada
        /// </returns>
        public List<Object> BuscarAmigo(string PalavraChave, object UsuarioLogado) {
            List<Amigo> amigos = AmigoDAO.BuscarAmigos(PalavraChave, (Model.Usuario)UsuarioLogado);
            return amigos;
        }



        public bool HasRegisteredUser() {
            throw new NotImplementedException();
        }

        public object Logar(string[] vetor) {
            throw new NotImplementedException();
        }
    }
}