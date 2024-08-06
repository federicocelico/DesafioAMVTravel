using AMVTravelData.Interfaces;
using AMVTravelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelData.Repositorios
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(AppDbContext context) : base(context) { }

    }
}
