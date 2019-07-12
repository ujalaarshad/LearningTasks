using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CountryMASter.Models
{
    public class help
    {
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public List<string> Countrieslist = new List<string>();
     
    }
}
