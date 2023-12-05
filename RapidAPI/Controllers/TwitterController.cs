using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Models;

namespace RapidAPI.Controllers
{
    public class TwitterController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=___venceremos__&user_id=96479162"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "twitter154.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TwitterViewModel>(body);
                return View(values);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Index(string userName)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://twitter154.p.rapidapi.com/user/details?username={userName}&user_id=96479162"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "twitter154.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TwitterViewModel>(body);
                return View(values);
            }

        }
    }
}
