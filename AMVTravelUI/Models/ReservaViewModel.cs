using System;
using System.ComponentModel.DataAnnotations;

namespace AMVTravelUI.Models
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string TourNombre { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
