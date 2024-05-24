using Dominio.Dtos;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface ILibroService
    {
        LibroCreadoDto Registrar(CrearLibroDto dto);
        Libro Consultar(int idLibro);
        bool Actualizar(int idLibro, ActualizarLibroDto dto);
        bool Eliminar(int idLibro);
    }
}
