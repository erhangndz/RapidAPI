using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Rename;
using Newtonsoft.Json;
using RapidAPI.Models;

namespace RapidAPI.Controllers
{
    public class ExchangeController : Controller
    {
        [HttpGet] 
        public async Task<IActionResult> Index()
        {
            var enumValues = Enum.GetValues(typeof(Currencies.Currency)).Cast<Currencies.Currency>();
            var selectList = new SelectList(enumValues);

            ViewBag.kurlar = selectList;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=USD&locale=tr"),
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
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.exchange_rates);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string rate)
        {
            var enumValues = Enum.GetValues(typeof(Currencies.Currency)).Cast<Currencies.Currency>();
            var selectList = new SelectList(enumValues);
            ViewBag.rate = rate+"/";
            ViewBag.kurlar = selectList;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={rate}" + "&locale=tr"),
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
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.exchange_rates);
            }
           
        }
    }
}
