using System;
using System.Collections.Generic;

namespace AMVTravelData.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}
