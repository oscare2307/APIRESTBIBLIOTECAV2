using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos
{
    public class CrearPrestamoDto
    {
        public int UsuarioId { get; set; }
        public int IdentificacionUsuario { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
