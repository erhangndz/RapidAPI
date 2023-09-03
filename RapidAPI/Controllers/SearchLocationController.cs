using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Models;
using System.Drawing;

namespace RapidAPI.Controllers
{
    public class SearchLocationController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);
                
                ViewBag.id = values.Select(x=>x.dest_id).FirstOrDefault();
                return View(values.Take(1).ToList());
            }
        }



        [HttpPost]
        public async Task<IActionResult> Index(string cityName)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);


            
            return View(values.Take(1).ToList());


        }


    }
}
