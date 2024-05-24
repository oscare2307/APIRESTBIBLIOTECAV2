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
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly DbContexto _context;
        public PrestamoRepository(DbContexto context)
        {

            _context = context;
        }

        public Prestamo Consultar(int id)
        {
            return _context.Prestamos.Find(id);
        }

        public Prestamo ConsultarPrestamo(int idPrestamo)
        {
            return _context.Prestamos.FirstOrDefault(x => x.IdPrestamo.Equals(idPrestamo));
        }


        public bool Registrar(Prestamo prestamo)
        {
            _context.Add(prestamo);
            return _context.SaveChanges() > 0;
        }
        public List<Prestamo> ConsultarUsuario(int usuarioId) {
        
            return _context.Prestamos.Where(p=>p.UsuarioId == usuarioId).ToList();
        }

        public bool Actualizar(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            return _context.SaveChanges() > 0;
        }
        public bool Eliminar(Prestamo prestamo)
        {
            _context.Prestamos.Remove(prestamo);
            return _context.SaveChanges() > 0;
        }
    }
}
