using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PharmacySupplyApp.Helpers
{
    public class Client : IClient
    {
        private readonly IConfiguration _config;
        public HttpClient client;
        public Client(IConfiguration config)
        {
            _config = config;
            client = new HttpClient();
        }
        public HttpClient GetAuthClient()
        {
            client.BaseAddress = new Uri(_config["Uri:Auth"]);
            return client;
        }
        public HttpClient GetMedRepClient()
        {
            client.BaseAddress = new Uri(_config["Uri:MRS"]);
            return client;
        }
        public HttpClient GetMedSupplyClient()
        {
            client.BaseAddress = new Uri(_config["Uri:PMS"]);
            return client;
        }

        public HttpClient GetMedStockClient()
        {
            client.BaseAddress = new Uri(_config["Uri:MS"]);
            return client;
        }
    }
}
