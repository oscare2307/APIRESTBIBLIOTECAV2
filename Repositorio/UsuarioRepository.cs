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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContexto _context;
        public UsuarioRepository(DbContexto context)
        {

            _context = context;
        }

        public Usuario Consultar(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario ConsultarUsuario(int IdentificacionUsuario)
        {
            return _context.Usuarios.FirstOrDefault(x => x.IdentificacionUsuario.Equals(IdentificacionUsuario));
        }


        public bool Registrar(Usuario usuario)
        {
            _context.Add(usuario);
            return _context.SaveChanges() > 0;
        }

        public bool Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return _context.SaveChanges() > 0;
        }

        public bool Eliminar(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            return _context.SaveChanges() > 0;
        }
    }
}
