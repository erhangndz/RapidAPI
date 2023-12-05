using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Models;

namespace RapidAPI.Controllers
{
    public class TranslateController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string text)
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://text-translator2.p.rapidapi.com/translate"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "text-translator2.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "source_language", "en" },
        { "target_language", "tr" },
        { "text", $"{text}" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<TranslateViewModel>(body);
                ViewBag.text = values.data.translatedText;
                return View();
                
            }
           
        }
    }
}
