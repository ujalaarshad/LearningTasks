using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountryMASter.Helper
{
    public class CountryApi
    {
        public HttpClient Initial() {
            var Client = new HttpClient();
            Client.BaseAddress=new Uri("http://localhost:13250/");
                return Client;
        }

         

    }
}
