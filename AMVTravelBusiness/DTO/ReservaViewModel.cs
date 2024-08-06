using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelBusiness.DTO
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string TourNombre { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
