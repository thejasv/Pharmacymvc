using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacySupplyApp.Helpers
{
    public interface IClient
    {
        public HttpClient GetAuthClient();
        public HttpClient GetMedRepClient();
        public HttpClient GetMedSupplyClient();
        public HttpClient GetMedStockClient();
    }
}
