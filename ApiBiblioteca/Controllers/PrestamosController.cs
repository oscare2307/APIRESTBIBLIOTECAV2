using Dominio.Dtos;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.Interfaces;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;
        public PrestamosController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet("{id}")]
        public ActionResult<Prestamo> Consultar(int id)
        {
            return Ok(_prestamoService.Consultar(id));
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearPrestamoDto crearPrestamoDto)
        {


            if ((crearPrestamoDto.IdentificacionUsuario != 0)
                || !String.IsNullOrEmpty(crearPrestamoDto.ISBN))

            {

                var prestamoCreado = _prestamoService.Registrar(crearPrestamoDto);

                if (prestamoCreado == null)
                {
                    return BadRequest($"El usuario con identificación {crearPrestamoDto.IdentificacionUsuario} no esta registrado por lo cual no se puede realizar el prestamo");
                }

                return Ok(prestamoCreado);

            }
            else
            {

                return BadRequest("Error en los datos de entrada");
            }

        }


        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] ActualizarPrestamoDto actualizarPrestamoDto)
        {
            if (actualizarPrestamoDto == null || id == 0)
            {
                return BadRequest("Datos de entrada inválidos.");
            }

            var prestamoExistente = _prestamoService.Consultar(id);
            if (prestamoExistente == null)
            {
                return NotFound($"No se encontró el préstamo con ID {id}.");
            }

            try
            {
                var prestamoActualizado = _prestamoService.Actualizar(id, actualizarPrestamoDto);
                return Ok(prestamoActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el préstamo: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _prestamoService.Eliminar(id);
            if (eliminado)
            {
                return Ok("Préstamo eliminado correctamente.");
            }
            else
            {
                return NotFound($"No se encontró el préstamo con ID {id}.");
            }
        }
    }
}

