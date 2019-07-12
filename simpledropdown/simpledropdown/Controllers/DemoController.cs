using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simpledropdown.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace simpledropdown.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : Controller
    {
        private readonly DatabaseContext _context;
        public DemoController(DatabaseContext context)
        {
            _context = context;
        }



        // GET: api/<controller>
        [HttpGet]
        public List<CountryMaster> Get() {
            return _context.CountryMaster.ToList();
        }
        [HttpPost]
        public JsonResult Get([FromBody] CountryMaster m)
        {
            var response = _context.Add(m);
            _context.SaveChanges();

            return Json(new { sucess = true, result = "countryname" });
            
        }

       
    }
}


      
