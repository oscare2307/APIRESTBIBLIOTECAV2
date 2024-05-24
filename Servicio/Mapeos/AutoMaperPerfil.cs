using AutoMapper;
using Dominio.Dtos;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Mapeos
{
     public class AutoMaperPerfil : Profile
    {
        public AutoMaperPerfil()
        {
            CreateMap<CrearLibroDto, Libro>();

            CreateMap<Libro, LibroCreadoDto>();

            CreateMap<CrearPrestamoDto, Prestamo>();

            CreateMap<Prestamo, PrestamoCreadoDto>();

            CreateMap<CrearUsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioCreadoDto>();

        }
    }
}
