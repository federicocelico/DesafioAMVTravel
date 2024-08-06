using AMVTravelBusiness.DTO;
using AMVTravelBusiness.Interfaces;
using AMVTravelData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVTravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReservaViewModel>>> GetReservas()
        {
            var result = await _reservaService.GetAllReservasAsync();
            if (!result.IsSuccess)
            {
                return StatusCode(500, "Error al obtener las reservas.");
            }

            var reservas = result.Data;

            var reservaViewModels = reservas.Select(r => new ReservaViewModel
            {
                Id = r.Id,
                Cliente = r.Cliente,
                FechaReserva = r.FechaReserva,
                TourNombre = r.Tour.Nombre
            }).ToList();

            return Ok(reservaViewModels);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var result = await _reservaService.DeleteReservaAsync(id);

            if (result.IsSuccess)
            {
                return Ok(new { success = true });
            }

            return NotFound(new { success = false, message = "No se pudo eliminar la reserva." });
        }
    }
}
