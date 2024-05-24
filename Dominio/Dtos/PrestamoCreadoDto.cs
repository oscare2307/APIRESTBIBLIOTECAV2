using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos
{
    public class PrestamoCreadoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int IdentificacionUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
