using AMVTravelBusiness.Interfaces;
using AMVTravelData.Models;
using AMVTravelBusiness.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVTravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<Tour>>>> GetTours()
        {
            var result = await _tourService.GetAllToursAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return StatusCode(500, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<Tour>>> GetTour(int id)
        {
            var result = await _tourService.GetTourByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Tour>>> CreateTour([FromBody] Tour tour)
        {
            if (tour == null)
            {
                return BadRequest("Los datos del tour no pueden estar vacios.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _tourService.CreateTourAsync(tour);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, result);
            }
            return StatusCode(500, result);
        }

        [HttpPost("{id}/reserve")]
        public async Task<ActionResult<Result<bool>>> ReserveTour(int id, [FromBody] string cliente)
        {
            if (string.IsNullOrEmpty(cliente))
            {
                return BadRequest("El nombre del cliente no puede estar vacío.");
            }

            var result = await _tourService.ReserveTourAsync(id, cliente);
            if (result.IsSuccess)
            {
                return Ok(new { success = true });
            }

            return NotFound(new { success = false, message = "No se pudo reservar el tour." });
        }
    }
}
