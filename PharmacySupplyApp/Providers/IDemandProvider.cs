using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PharmacySupplyApp.Models;

namespace PharmacySupplyApp.Providers
{
    public interface IDemandProvider
    {
        public Task<HttpResponseMessage> GetStock();
        public Task<HttpResponseMessage> GetSupply(List<MedicineDemand> demands,string token);
        public List<MedicineDemand> GetDemand(List<MedicineStock> stocks);
        public void AddSupplyToDB(List<Supply> supplies);
    }
}
