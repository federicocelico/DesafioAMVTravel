using AMVTravelBusiness.Enums;
using AMVTravelBusiness.Helpers;
using AMVTravelBusiness.Interfaces;
using AMVTravelData.Interfaces;
using AMVTravelData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IRepository<Reserva> _reservaRepository;

        public ReservaService(IRepository<Reserva> reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task<Result<List<Reserva>>> GetAllReservasAsync()
        {
            try
            {
                var reservas = await _reservaRepository.GetAll()
                    .Include(r => r.Tour)
                    .ToListAsync();

                return Result<List<Reserva>>.Success(reservas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reservas: {ex.Message}");
                return Result<List<Reserva>>.Failure(ReservaErrorCode.ErrorAlObtenerReservas, "Error al obtener las reservas.");
            }
        }
        public async Task<Result<bool>> DeleteReservaAsync(int id)
        {
            try
            {
                var reserva = await _reservaRepository.GetByIdAsync(id);
                if (reserva == null)
                {
                    return Result<bool>.Failure(ReservaErrorCode.ReservaNoExiste, "La reserva no existe.");
                }

                await _reservaRepository.RemoveAsync(reserva);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar reserva: {ex.Message}");
                return Result<bool>.Failure(ReservaErrorCode.ErrorAlEliminarReserva, "Error al eliminar la reserva.");
            }
        }

        public async Task<Result<bool>> CreateReservaAsync(Reserva reserva)
        {
            try
            {
                if (reserva == null)
                {
                    return Result<bool>.Failure(ReservaErrorCode.InformacionDeReservaInvalida, "Información de reserva inválida.");
                }

                await _reservaRepository.AddAsync(reserva);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear reserva: {ex.Message}");
                return Result<bool>.Failure(ReservaErrorCode.ErrorCrearReserva, "Error al crear la reserva.");
            }
        }

        public async Task<Result<Reserva>> GetReservaByIdAsync(int id)
        {
            try
            {
                var reserva = await _reservaRepository.GetByIdAsync(id);
                if (reserva == null)
                {
                    return Result<Reserva>.Failure(ReservaErrorCode.ReservaNoExiste, "La reserva no existe.");
                }

                return Result<Reserva>.Success(reserva);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reserva: {ex.Message}");
                return Result<Reserva>.Failure(ReservaErrorCode.ErrorAlObtenerReservas, "Error al obtener la reserva.");
            }
        }

        public async Task<Result<List<Reserva>>> GetReservasByClienteAsync(string cliente)
        {
            try
            {
                var reservas = await Task.Run(() => _reservaRepository.Find(r => r.Cliente == cliente).ToList());
                return Result<List<Reserva>>.Success(reservas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reservas para el cliente {cliente}: {ex.Message}");
                return Result<List<Reserva>>.Failure(ReservaErrorCode.ErrorAlObtenerReservas, "Error al obtener las reservas del cliente.");
            }
        }
    }
}
