using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPrestamoRepository
    {
        bool Registrar(Prestamo prestamo);

        Prestamo Consultar(int id);
        Prestamo ConsultarPrestamo(int prestamoId);
        List<Prestamo> ConsultarUsuario(int usuarioId);
        bool Actualizar(Prestamo prestamo);
        bool Eliminar(Prestamo prestamo);
    }
}
