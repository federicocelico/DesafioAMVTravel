using AMVTravelData.Interfaces;
using AMVTravelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelData.Repositorios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public Usuario GetByNombreUsuario(string nombreUsuario)
        {
            return _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == nombreUsuario);
        }
    }
}
