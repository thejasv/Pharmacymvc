
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PharmacySupplyApp.Helpers;
using PharmacySupplyApp.Repositories;
using PharmacySupplyApp.Models;

namespace PharmacySupplyApp.Providers
{
    public class DemandProvider : IDemandProvider
    {
        readonly HttpClient httpClient = new HttpClient();

        private readonly HttpClient httpClient1;
        private readonly ISupplyRepo _supplyRepo;

        public DemandProvider(ISupplyRepo supplyRepo,IClient client)
        {
            _supplyRepo = supplyRepo;
            httpClient1 = client.GetMedSupplyClient();
        }
        public async Task<HttpResponseMessage> GetSupply(List<MedicineDemand> demands, string token)
        {
            try
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient1.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient1.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                StringContent content = new StringContent(JsonConvert.SerializeObject(demands), Encoding.UTF8, "application/json");
                var response = await httpClient1.PostAsync("PharmacySupply/Get", content);
                
                return response;
            }
            catch (Exception)
            {
              
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetStock()
        {
            try
            {
                var response = await httpClient.GetAsync("https://localhost:44394/MedicineStockInformation");
               
                return response;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<MedicineDemand> GetDemand(List<MedicineStock> stocks)
        {
            try
            {
                List<MedicineDemand> demands = new List<MedicineDemand>();
                foreach (var stock in stocks)
                {
                    MedicineDemand demand = new MedicineDemand() { MedicineName = stock.Name, Count = 0 };
                    demands.Add(demand);
                }
               
                return demands;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void AddSupplyToDB(List<Supply> supplies)
        {
            try
            {
                foreach (var s in supplies)
                {
                    SupplyDto supply = new SupplyDto() { MedicineName = s.MedicineName, PharmacyName = s.PharmacyName, SupplyCount = s.SupplyCount };
                    
                    _supplyRepo.Add(supply);
                }
            }
            catch (Exception)
            {
               
                throw;
            }
        }
    }
}
