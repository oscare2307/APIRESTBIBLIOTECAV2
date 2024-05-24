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
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public PrestamoService(IPrestamoRepository repository, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public Prestamo Consultar(int id)
        {

            return _repository.Consultar(id);
        }

        public PrestamoCreadoDto Registrar(CrearPrestamoDto dto)
        {
            var usuario = _usuarioRepository.Consultar(dto.UsuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
                
            }

            var librosPrestados = _repository.ConsultarUsuario(dto.UsuarioId);
            if (librosPrestados.Count > 0)
            {
                throw new Exception("El Usuario tiene un préstamo pendiente");
            }

            var prestamo = _mapper.Map<Prestamo>(dto);

            int prestamosDias;
            switch (usuario.TipoUsuario)
            {
                case 1:
                    prestamosDias = 10;
                    break;
                case 2:
                    prestamosDias = 8;
                    break;
                case 3:
                    prestamosDias = 7;
                    break;
                default:
                    throw new Exception("El tipo de usuario no existe");
            }
            prestamo.FechaMaximaDevolucion = CalcularFechaDevolucion(DateTime.Now, prestamosDias);

            _repository.Registrar(prestamo);

            var prestamoCreado = _mapper.Map<PrestamoCreadoDto>(prestamo);
            return prestamoCreado;
        }
        private DateTime CalcularFechaDevolucion(DateTime inicio, int dias)
        {
            int diasAgregados = 0;
            DateTime fechaDevolucion = inicio;
            while (diasAgregados < dias)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                if (fechaDevolucion.DayOfWeek != DayOfWeek.Saturday && fechaDevolucion.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasAgregados++;
                }
            }
            return fechaDevolucion;
        }

        public Prestamo Actualizar(int id, ActualizarPrestamoDto dto)
        {
            var prestamoExistente = _repository.Consultar(id);
            if (prestamoExistente == null)
            {
                throw new Exception($"No se encontró el préstamo con ID {id}.");
            }

            _mapper.Map(dto, prestamoExistente); // Actualiza el prestamoExistente con los datos del dto

            if (!_repository.Actualizar(prestamoExistente))
            {
                throw new Exception("Error al actualizar el préstamo.");
            }

            return prestamoExistente;
        }

        public bool Eliminar(int id)
        {
            var prestamoExistente = _repository.Consultar(id);
            if (prestamoExistente != null)
            {
                return _repository.Eliminar(prestamoExistente);
            }
            return false;
        }
    }
}

