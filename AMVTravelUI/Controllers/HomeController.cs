using AMVTravelUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AMVTravelUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7244/api/tours");

            var homeViewModel = new HomeViewModel();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(json);
                homeViewModel.Tours = JsonConvert.DeserializeObject<List<TourViewModel>>(Convert.ToString(result.data));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al cargar los tours.");
                homeViewModel.Tours = new List<TourViewModel>();
            }

            homeViewModel.MensajeBienvenida = "Bienvenido a AMV Travel";

            return View(homeViewModel);
        }
    }
}
