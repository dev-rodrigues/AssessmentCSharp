using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio.UsuarioRepository {
    public interface IRepositorioUsuario {

        List<T> Buscar<T>(string PalavraChave, Object UsuarioLogado) where T : class;
    }
}
