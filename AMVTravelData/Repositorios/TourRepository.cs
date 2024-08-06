using AMVTravelData.Interfaces;
using AMVTravelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelData.Repositorios
{
    public class TourRepository : Repository<Tour>, ITourRepository
    {
        public TourRepository(AppDbContext context) : base(context) { }
    }
}
