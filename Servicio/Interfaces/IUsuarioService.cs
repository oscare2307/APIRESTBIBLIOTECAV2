using Dominio.Dtos;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioCreadoDto Registrar(CrearUsuarioDto dto);
        Usuario Consultar(int id);
        UsuarioCreadoDto Actualizar(int id, ActualizarUsuarioDto dto);
        bool Eliminar(int id);
    }
}
