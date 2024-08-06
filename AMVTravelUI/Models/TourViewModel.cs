using System;
using System.ComponentModel.DataAnnotations;

namespace AMVTravelUI.Models
{
    public class TourViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Destino { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public decimal Precio { get; set; }
    }
}
