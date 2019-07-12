using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CountryMASter.Models;
using CountryMASter.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CountryMASter.Controllers
{
    public class HomeController : Controller
    {
        CountryApi api = new CountryApi();

        public IActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Post(CountryMaster c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44395/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Demo", c);

            if (response.IsSuccessStatusCode == true)
            {
                return View();
            }
            return View(c);
        }
        
        public async Task<IActionResult> Succeed(CountryMaster c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44395/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Demo", c);

            if (response.IsSuccessStatusCode == true)
            {
                return View();
            }
            
            return View();
        }
            public IActionResult checkbox()
        {

            help h = new help();
            h.Countrieslist.Add("bangladesh");
            h.Countrieslist.Add("newzealand");
            h.Countrieslist.Add("India");
           

            return View(h);
        }
        [HttpPost]
        public IActionResult checkbox(help h)
        {
            CountryMaster c = new CountryMaster();
            c.Name = h.Name;
            return RedirectToAction("Succeed", c);
           /* HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44395/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Demo", c);

            if (response.IsSuccessStatusCode == true)
            {
                return View();
            }*/
            
      

        }

        public async Task<string> GetCountryAsync(CountryMaster c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44395/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Demo", c);

           
            //Use - when you want a logical delay without blocking the current thread.  
            return "India";
        }
        public async Task<IActionResult> Index()
        {
            List<CountryMaster> list = new List<CountryMaster>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Demo");
            if (res.IsSuccessStatusCode) { var result = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CountryMaster>>(result);
            }
            return View(list);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
