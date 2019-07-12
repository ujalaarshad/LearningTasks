using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CountryMASter.Models
{
    public class CountryMaster
    {
        
            [Key]
            public int ID { get; set; }

            [Display(Name = "Country Name")]
            public string Name { get; set; }
      
    }
    }


