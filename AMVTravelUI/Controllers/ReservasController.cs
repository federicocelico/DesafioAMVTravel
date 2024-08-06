using AMVTravelUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AMVTravelUI.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReservasController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7244/api/reservas");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var reservas = JsonConvert.DeserializeObject<List<ReservaViewModel>>(json);

                return View(reservas);
            }

            ModelState.AddModelError(string.Empty, "Error al cargar las reservas.");
            return View(new List<ReservaViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de reserva inválido.");
            }

            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7244/api/reservas/{id}");

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { success = true });
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error al eliminar la reserva: {errorContent}");
            return StatusCode((int)response.StatusCode, errorContent);
        }
    }
}
