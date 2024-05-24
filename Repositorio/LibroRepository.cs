using Dominio.Entities;
using Repositorio.Data;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class LibroRepository : ILibroRepository
    {
        private readonly DbContexto _context;
        public LibroRepository(DbContexto context)
        {

            _context = context;
        }

        public Libro Consultar(int id)
        {
            return _context.Libros.Find(id);
        }

        public Libro Consultar(string ISBN)
        {
            return _context.Libros.FirstOrDefault(x => x.ISBN.Equals(ISBN));
        }


        public bool Registrar(Libro libro)
        {
            _context.Add(libro);
            return _context.SaveChanges() > 0;
        }

        public bool Actualizar(Libro libro)
        {
            _context.Libros.Update(libro);
            return _context.SaveChanges() > 0;
        }

        public bool Eliminar(Libro libro)
        {
            _context.Libros.Remove(libro);
            return _context.SaveChanges() > 0;
        }
    }
}
