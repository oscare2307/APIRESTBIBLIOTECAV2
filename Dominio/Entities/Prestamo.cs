using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Prestamo : EntidadBase
    {
        public int IdPrestamo { get; set; }
        public string ISBN { get; set; }
        public int UsuarioId {  get; set; }
        public int IdentificacionUsuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
