using AMVTravelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelData.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByNombreUsuario(string nombreUsuario);
    }
}
