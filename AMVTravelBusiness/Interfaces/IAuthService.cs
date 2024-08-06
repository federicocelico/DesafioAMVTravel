using AMVTravelBusiness.Enums;
using AMVTravelBusiness.Helpers;
using AMVTravelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Interfaces
{
    public interface IAuthService
    {
        Result<Usuario> Login(string nombreUsuario, string contraseña);
    }
}
