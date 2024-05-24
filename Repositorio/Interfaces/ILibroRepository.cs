using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface ILibroRepository
    {
        bool Registrar(Libro libro);

        Libro Consultar(int id);
        Libro Consultar(string ISBN);
        bool Actualizar(Libro libro);
        bool Eliminar(Libro libro);
    }
}
