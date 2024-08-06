using AMVTravelUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AMVTravelUI.Controllers
{

    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AccountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var client = _clientFactory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7244/api/Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            var errorResponse = await response.Content.ReadAsStringAsync();
            try
            {
                dynamic errorObject = JsonConvert.DeserializeObject<dynamic>(errorResponse);
                string errorMessage = errorObject?.message ?? "Error desconocido";

                ModelState.AddModelError(string.Empty, errorMessage);
            }
            catch (JsonException ex)
            {
                ModelState.AddModelError(string.Empty, "Error al procesar la respuesta de error.");
            }

            return View(request);
        }
    }
}
