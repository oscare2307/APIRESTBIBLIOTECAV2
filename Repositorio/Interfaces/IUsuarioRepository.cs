using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Registrar(Usuario usuario);

        Usuario Consultar(int id);
        Usuario ConsultarUsuario(int IdentificacionUsuario);
        bool Actualizar(Usuario usuario);
        bool Eliminar(Usuario usuario);
    }
}
