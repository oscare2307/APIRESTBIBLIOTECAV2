using AutoMapper;
using Dominio.Dtos;
using Dominio.Entities;
using Repositorio.Interfaces;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Usuario Consultar(int id)
        {

            return _repository.Consultar(id);
        }

        public UsuarioCreadoDto Registrar(CrearUsuarioDto dto)
        {


            var existe = _repository.Consultar(dto.IdentificacionUsuario);

            if (existe is null)
                
            {
               
                var usuario = _mapper.Map<Usuario>(dto);
                usuario.FechaCreacion = DateTime.Now;
                int tipoUser = validarTipoUser(dto.TipoUsuario);
                if(tipoUser == -1)
                {

                    return null;
                }

                usuario.TipoUsuario = tipoUser;
                _repository.Registrar(usuario);

                var usuarioCreado = _mapper.Map<UsuarioCreadoDto>(usuario);

                return usuarioCreado;

            }

            return null;
        }


        public UsuarioCreadoDto Actualizar(int id, ActualizarUsuarioDto dto)
        {
            var usuarioExistente = _repository.Consultar(id);

            if (usuarioExistente == null)
            {
                return null; // Manejo de error si el usuario no se encuentra
            }

            // Actualizar los campos del usuario existente con los datos del DTO
            usuarioExistente.NombreCompleto = dto.NombreCompleto;
            usuarioExistente.FechaNacimiento = dto.FechaNacimiento;
            usuarioExistente.CorreoElectronico = dto.CorreoElectronico;
            usuarioExistente.Genero = dto.Genero;
            usuarioExistente.TipoUsuario = dto.TipoUsuario;

            // Guardar los cambios en la base de datos
            bool actualizacionExitosa = _repository.Actualizar(usuarioExistente);

            if (actualizacionExitosa)
            {
                // Mapear el usuario actualizado a un DTO y devolverlo
                var usuarioActualizadoDto = _mapper.Map<UsuarioCreadoDto>(usuarioExistente);
                return usuarioActualizadoDto;
            }
            else
            {
                // Manejo de error si la actualización falla
                return null;
            }
        }

        private int validarTipoUser(int tipoUser)
        {
            switch (tipoUser)
            {
                case 1:
                case 2:
                case 3:
                    return tipoUser;
                default:
                    return -1;
            }
        }

        public bool Eliminar(int id)
        {
            var usuarioExistente = _repository.Consultar(id);

            if (usuarioExistente == null)
            {
                return false; // Manejo de error si el usuario no se encuentra
            }

            return _repository.Eliminar(usuarioExistente);
        }
    }
}

