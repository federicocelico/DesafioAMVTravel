using System.ComponentModel.DataAnnotations;

namespace AMVTravelUI.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}
