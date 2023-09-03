using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RapidAPI.Models;

namespace RapidAPI.Controllers
{
    public class BookingController : Controller
    {
        

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=TRY&dest_id=-1456928&locale=tr&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
                var values = JsonConvert.DeserializeObject<BookingViewModel>(body);
                return View(values.results.ToList());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Index(string cityName,string destid)
        {

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}" + "&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            var response2 = await client2.SendAsync(request2);
            
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body2);

                
            
            destid = values2.Select(x => x.dest_id).FirstOrDefault();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=TRY&dest_id={destid}&locale=tr&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
                var values = JsonConvert.DeserializeObject<BookingViewModel>(body);
                return View(values.results.ToList());
            }

        }
    }
}
