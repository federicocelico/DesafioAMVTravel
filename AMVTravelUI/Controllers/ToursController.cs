using AMVTravelUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelUI.Controllers
{
    public class ToursController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ToursController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7244/api/tours");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(json);
                var tours = JsonConvert.DeserializeObject<List<TourViewModel>>(Convert.ToString(result.data));

                return View(tours);
            }

            ModelState.AddModelError(string.Empty, "Error al cargar los tours.");
            return View(new List<TourViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TourViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var client = _clientFactory.CreateClient();
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7244/api/tours", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { redirectUrl = Url.Action("Index", "Home") });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al crear el tour: {errorContent}");

                return StatusCode((int)response.StatusCode, errorContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al crear el tour: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al procesar su solicitud.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Reserve([FromBody] ReservaRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Cliente))
                {
                    return BadRequest("La información de la reserva es incorrecta.");
                }

                var client = _clientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(request.Cliente), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"https://localhost:7244/api/tours/{request.Id}/reserve", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { success = true });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al reservar el tour: {errorContent}");

                return StatusCode((int)response.StatusCode, errorContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al reservar el tour: {ex.Message}");
                return StatusCode(500, "Ocurrió un error al procesar su solicitud.");
            }
        }
    }
}
