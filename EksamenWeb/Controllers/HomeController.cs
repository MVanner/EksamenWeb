using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Entities.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EksamenWeb.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly FlightDbContext _db;
        private  readonly HttpClient _client;

        private Uri BaseEndPoint { get; set; }
        public HomeController(FlightDbContext db)
        {
            BaseEndPoint = new Uri("https://localhost:44335/api/Flight");
            _client = new HttpClient();
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Overview(string FromLocation, string ToLocation)
        {
            if (FromLocation == null && ToLocation == null)
            {
                var response = await _client.GetAsync(BaseEndPoint, HttpCompletionOption.ResponseHeadersRead);
                //response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<Flight>>(data));
            }
            else
            {
                var response = await _client.GetAsync(BaseEndPoint + "/" + FromLocation + "/" + ToLocation, HttpCompletionOption.ResponseHeadersRead);
                //response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<Flight>>(data));
            }
        }
        public async Task<IActionResult> GetTrip(int Id)
        {
            if (Id == null)
            {
                var response = await _client.GetAsync(BaseEndPoint, HttpCompletionOption.ResponseHeadersRead);
                //response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<Flight>>(data));
            }
            else
            {
                var response = await _client.GetAsync(BaseEndPoint + "/" + Id.ToString() , HttpCompletionOption.ResponseHeadersRead);
                //response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<Flight>>(data));
            }
            //var response = await _client.GetAsync(BaseEndPoint + "/" + Id.ToString(), HttpCompletionOption.ResponseHeadersRead);
            //response.EnsureSuccessStatusCode();
            //var data = await response.Content.ReadAsStringAsync();
            //return View(JsonConvert.DeserializeObject<Flight>(data));
        }
    }
}