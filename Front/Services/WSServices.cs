using Front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Front.Services
{
    public class WSServices
    {
        static HttpClient client = new HttpClient();

        private static WSServices _instance { get; set; }

        private WSServices()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:2012/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WSServices GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WSServices();
            }
            return _instance;
        }

        public async Task<Compte> GetCompteByEmail(string email)
        {
            Compte compte = null;
            HttpResponseMessage response = await client.GetAsync(string.Concat("Compte/GetCompteByEmail", email));
            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<Compte>();
            }
            return compte;
        }
    }

}
