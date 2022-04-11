using Newtonsoft.Json;
using Softplan.Projeto2.Api.Interface;
using Softplan.Projeto2.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Service
{
    public class WebApiClientService : IWebApiClientService
    {
        public JurosDTO ObterTaxaJuros(string uri)
        {
            JurosDTO jurosDTO = null;

            try
            {
                var httpClient = new HttpClient();

                HttpResponseMessage response = httpClient.GetAsync($"http://localhost:57235/api/{uri}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    jurosDTO = JsonConvert.DeserializeObject<JurosDTO>(responseBody);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return jurosDTO;
        }
    }
}
