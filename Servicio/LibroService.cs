using AutoMapper;
using Dominio.Entities;
using Dominio.Dtos;
using Repositorio.Interfaces;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Libro Consultar(int id)
        {

            return _repository.Consultar(id);
        }

        public LibroCreadoDto Registrar(CrearLibroDto dto)
        {


            var existe = _repository.Consultar(dto.Titulo);

            if (existe is null)
            {

                var libro = _mapper.Map<Libro>(dto);
                libro.FechaCreacion = DateTime.Now;

                // Viola el principio de ID
                //ProductoRepository _repository = new ProductoRepository();
                _repository.Registrar(libro);

                var libroCreado = _mapper.Map<LibroCreadoDto>(libro);

                return libroCreado;

            }

            return null;
        }

        public bool Actualizar(int id, ActualizarLibroDto dto)
        {
            var libroExistente = _repository.Consultar(id);

            if (libroExistente == null)
            {
                // Manejar el error si el libro no existe
                return false;
            }

            // Actualizar los campos del libro existente con los datos del DTO
            libroExistente.Titulo = dto.Titulo;
            libroExistente.Autor = dto.Autor;
            libroExistente.Editorial = dto.Editorial;
            libroExistente.FechaPublicacion = dto.FechaPublicacion;
            libroExistente.ISBN = dto.ISBN;
            libroExistente.Genero = dto.Genero;
            libroExistente.Sinopsis = dto.Sinopsis;
            libroExistente.Idioma = dto.Idioma;

            // Guardar los cambios en el repositorio y devolver true si la actualización fue exitosa
            return _repository.Actualizar(libroExistente);
        }

        public bool Eliminar(int idLibro)
        {
            var libroExistente = _repository.Consultar(idLibro);

            if (libroExistente == null)
            {
                // Manejo de error si el libro no se encuentra
                return false;
            }

            return _repository.Eliminar(libroExistente);
        }
    }
}
