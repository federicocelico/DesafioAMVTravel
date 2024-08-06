using AMVTravelData.Models;
using AMVTravelData.Interfaces;
using AMVTravelBusiness.Interfaces;
using AMVTravelBusiness.Helpers;
using AMVTravelBusiness.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IReservaRepository _reservaRepository;

        public TourService(ITourRepository tourRepository, IReservaRepository reservaRepository)
        {
            _tourRepository = tourRepository;
            _reservaRepository = reservaRepository;
        }

        public async Task<Result<List<Tour>>> GetAllToursAsync()
        {
            try
            {
                var tours = await _tourRepository.GetAll().ToListAsync();
                return Result<List<Tour>>.Success(tours);
            }
            catch (Exception ex)
            {
                return Result<List<Tour>>.Failure(TourErrorCode.ErrorCrearTour, "Error al obtener los tours.");
            }
        }

        public async Task<Result<Tour>> GetTourByIdAsync(int tourId)
        {
            try
            {
                var tour = await _tourRepository.GetByIdAsync(tourId);
                if (tour == null)
                {
                    return Result<Tour>.Failure(TourErrorCode.TourNoEncontrado, "Tour no encontrado.");
                }

                return Result<Tour>.Success(tour);
            }
            catch (Exception ex)
            {
                return Result<Tour>.Failure(TourErrorCode.ErrorCrearTour, "Error al obtener el tour.");
            }
        }

        public async Task<Result<Tour>> CreateTourAsync(Tour tour)
        {
            try
            {
                var existingTour = await _tourRepository.Find(t => t.Nombre == tour.Nombre).FirstOrDefaultAsync();
                if (existingTour != null)
                {
                    return Result<Tour>.Failure(TourErrorCode.TourYaExiste, "Ya existe un tour con este nombre.");
                }

                await _tourRepository.AddAsync(tour);
                return Result<Tour>.Success(tour, "Tour creado exitosamente.");
            }
            catch (Exception ex)
            {
                return Result<Tour>.Failure(TourErrorCode.ErrorCrearTour, "Error al crear el tour.");
            }
        }

        public async Task<Result<bool>> ReserveTourAsync(int tourId, string cliente)
        {
            try
            {
                var tour = await _tourRepository.GetByIdAsync(tourId);
                if (tour == null)
                {
                    return Result<bool>.Failure(TourErrorCode.TourNoEncontrado, "Tour no encontrado.");
                }

                var reserva = new Reserva
                {
                    Cliente = cliente,
                    TourId = tourId,
                    FechaReserva = DateTime.Now
                };

                await _reservaRepository.AddAsync(reserva);

                return Result<bool>.Success(true, "Reserva realizada exitosamente.");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(TourErrorCode.ErrorCrearTour, "Error al reservar el tour.");
            }
        }
    }
}