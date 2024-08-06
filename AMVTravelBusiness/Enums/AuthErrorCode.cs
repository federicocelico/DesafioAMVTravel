using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AMVTravelBusiness.Enums
{
    public enum AuthErrorCode
    {
        [Display(Description = "Error. Usuario no existe.")]
        UsuarioNoExiste = 1001,

        [Display(Description = "Error. La contraseña es incorrecta.")]
        ContraseñaIncorrecta = 1002,

        [Display(Description = "Autenticación exitosa.")]
        Exito = 1000
    }
}
