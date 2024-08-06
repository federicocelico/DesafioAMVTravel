using System;
using System.Collections.Generic;

namespace AMVTravelData.Models
{
    public partial class Reserva
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = null!;
        public DateTime FechaReserva { get; set; }
        public int TourId { get; set; }

        public virtual Tour Tour { get; set; } = null!;
    }
}
