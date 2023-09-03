using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Models;

namespace RapidAPI.Controllers
{
    public class BoxOfficeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://movies-tv-shows-database.p.rapidapi.com/?page=1"),
                Headers =
    {
        { "Type", "get-boxoffice-movies" },
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "movies-tv-shows-database.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BoxOfficeViewModel>(body);
                return View(values.movie_results);
            }
            
        }
    }
}
