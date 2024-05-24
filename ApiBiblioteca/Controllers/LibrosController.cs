using Dominio.Dtos;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.Interfaces;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> Consultar(int id)
        {
            return Ok(_libroService.Consultar(id));
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearLibroDto crearLibroDto)
        {


            if (!String.IsNullOrEmpty(crearLibroDto.Titulo)
                || !String.IsNullOrEmpty(crearLibroDto.Autor)
                || !String.IsNullOrEmpty(crearLibroDto.Editorial)
                || !String.IsNullOrEmpty(crearLibroDto.ISBN)
                || !String.IsNullOrEmpty(crearLibroDto.Idioma)
                || !String.IsNullOrEmpty(crearLibroDto.Sinopsis)
                || !String.IsNullOrEmpty(crearLibroDto.Genero))
            {

                var libroCreado = _libroService.Registrar(crearLibroDto);

                if (libroCreado == null)
                {
                    return BadRequest($"El libro que contiene ese titulo {crearLibroDto.Titulo} ya habia sido creado");
                }

                return Ok(libroCreado);


            }
            else
            {

                return BadRequest("Error en los datos de entrada");
            }

        }

        [HttpPut("{id}")]
        public ActionResult<LibroCreadoDto> Actualizar(int id, [FromBody] ActualizarLibroDto dto)
        {
            var libroActualizado = _libroService.Actualizar(id, dto);
            if (libroActualizado == null)
            {
                return NotFound($"El libro con ID {id} no fue encontrado.");
            }

            return Ok(libroActualizado);
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var exito = _libroService.Eliminar(id);
            if (exito)
            {
                return NoContent(); // Devuelve 204 si el libro se eliminó correctamente
            }
            return NotFound(); // Devuelve 404 si el libro no se encontró o no se pudo eliminar
        }
    }
}

