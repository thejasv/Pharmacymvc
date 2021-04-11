using Newtonsoft.Json;
using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Provider
{
    public class MedicineStockProvider : IMedicineStockProvider
    {
        
        public async Task<int> GetStock(string medicineName)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:59930")
            };
            var response = await client.GetAsync("MedicineStockInformation");
            if (!response.IsSuccessStatusCode)
            {
                
                return -1;
            }
            
            string stringStock = await response.Content.ReadAsStringAsync();
            var medicines = JsonConvert.DeserializeObject<List<MedicineStock>>(stringStock);
            var i = medicines.Where(x => x.Name == medicineName).FirstOrDefault();
            return i.NumberOfTabletsInStock;
        }
    }
}