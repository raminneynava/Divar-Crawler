using Divar_Crawler.DTOs;
using Divar_Crawler.Models;
using Divar_Crawler.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Divar_Crawler.Controllers
{
    public class HomeController : Controller
    {
        private readonly DivarService _divarScraper;
        private readonly CitiesService _citiesService;

        public HomeController(CitiesService citiesService, DivarService divarScraper)
        {
            _citiesService = citiesService;
            _divarScraper = divarScraper;

        }

        public async Task<IActionResult> IndexAsync()
        {
            var cities = await _citiesService.ReadCityJsonFile();
            ViewBag.City = cities;
            return View();
        }

        public async Task<IActionResult> GetPosts(int id, string cityName, string searchQuery)
        {
            var DivarResult = await _divarScraper.GetClassesFromURL(id, cityName, searchQuery);
            List<BoxPostDto> BoxPosts = new List<BoxPostDto>();
            foreach (var item in DivarResult)
            {
                BoxPosts.Add(item);
            }

            var random = new Random();
            BoxPosts = BoxPosts.OrderBy(x => random.Next()).ToList();
            return Json(BoxPosts);

        }
    }
}