using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Models;

namespace RapidAPI.Controllers
{
    public class MoviesSeriesController : Controller
    {
        [HttpGet]   
        public async Task<IActionResult> Index()
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://mdblist.p.rapidapi.com/?s=titanic"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "mdblist.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<MoviesSeriesViewModel>(body);
                return View(values.search.ToList());
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Index(string title)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://mdblist.p.rapidapi.com/?s={title}&l=100"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "mdblist.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<MoviesSeriesViewModel>(body);
                return View(values.search.ToList());
            }

        }
    }
}
