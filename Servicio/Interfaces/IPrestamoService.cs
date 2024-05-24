using Dominio.Dtos;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface IPrestamoService
    {
        PrestamoCreadoDto Registrar(CrearPrestamoDto dto);
        Prestamo Consultar(int id);
        Prestamo Actualizar(int id, ActualizarPrestamoDto dto);
        bool Eliminar(int id);
    }
}
