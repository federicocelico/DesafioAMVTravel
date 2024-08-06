using AMVTravelData.Models;
using AMVTravelBusiness.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Interfaces
{
    public interface ITourService
    {
        Task<Result<List<Tour>>> GetAllToursAsync();
        Task<Result<Tour>> GetTourByIdAsync(int tourId);
        Task<Result<Tour>> CreateTourAsync(Tour tour);
        Task<Result<bool>> ReserveTourAsync(int tourId, string cliente);
    }
}
