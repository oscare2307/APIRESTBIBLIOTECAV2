using Dominio.Dtos;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Servicio.Interfaces;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Consultar(int id)
        {
            return Ok(_usuarioService.Consultar(id));
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearUsuarioDto crearUsuarioDto)
        {


            if (!String.IsNullOrEmpty(crearUsuarioDto.NombreCompleto)
                || (crearUsuarioDto.IdentificacionUsuario!=0)
                || !String.IsNullOrEmpty(crearUsuarioDto.FechaNacimiento.ToString("yyyy-mm-dd"))
                || !String.IsNullOrEmpty(crearUsuarioDto.Genero)
                || (crearUsuarioDto.TipoUsuario!=0)
                || !String.IsNullOrEmpty(crearUsuarioDto.CorreoElectronico))
                
            {

                var usuarioCreado = _usuarioService.Registrar(crearUsuarioDto);

                if (!UserValido(crearUsuarioDto.TipoUsuario))
                {
                    return BadRequest("Este tipo de usuario no es valido");
                }

                if (usuarioCreado == null)
                {
                    return BadRequest($"El usuario ha sido registrado {crearUsuarioDto.NombreCompleto}");
                }

                return Ok(usuarioCreado);


            }
            else
            {

                return BadRequest("Error en los datos de entrada");
            }

           
        }
        private bool UserValido(int tipoUsuario)
        {
            var tipoValido = new[] { 1, 2, 3 };
            return tipoValido.Contains(tipoUsuario);
        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] ActualizarUsuarioDto dto)
        {
            var usuarioActualizado = _usuarioService.Actualizar(id, dto);

            if (usuarioActualizado == null)
            {
                return NotFound($"El usuario con ID {id} no se encontró.");
            }

            return Ok(usuarioActualizado);
        }


        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _usuarioService.Eliminar(id);

            if (eliminado)
            {
                return Ok("Usuario eliminado correctamente.");
            }
            else
            {
                return NotFound("Usuario no encontrado.");
            }
        }

    }
}

