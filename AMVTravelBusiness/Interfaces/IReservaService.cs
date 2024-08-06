using AMVTravelBusiness.Helpers;
using AMVTravelData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Interfaces
{
    public interface IReservaService
    {
        Task<Result<List<Reserva>>> GetAllReservasAsync();
        Task<Result<bool>> DeleteReservaAsync(int id);
        Task<Result<bool>> CreateReservaAsync(Reserva reserva);
        Task<Result<Reserva>> GetReservaByIdAsync(int id);
        Task<Result<List<Reserva>>> GetReservasByClienteAsync(string cliente);
    }
}
