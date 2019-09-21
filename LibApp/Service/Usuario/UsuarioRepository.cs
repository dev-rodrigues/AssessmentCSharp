using System;
using LibApp.DAO.Amigo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Repositorio.UsuarioRepository;
using LibApp.DAO.Amgio;

namespace LibApp.Service.Usuario {
    public class UsuarioRepository : IRepositorioUsuario {

        private IAmigo AmigoDAO = ServiceLab.GetInstanceOf<AmigoDAOImpl>();

        public List<T> Buscar<T>(string PalavraChave, object UsuarioLogado) where T : class {
            
            return null;
        }
    }
}