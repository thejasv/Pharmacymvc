using MedicalRepresentativeSchedule.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.Providers
{
    public class MedicineStockProvider:IMedicineStockProvider
    {
        List<MedicineStock> _stockData = new List<MedicineStock>() { };
       
        public async Task<List<MedicineStock>> GetMedicineStock()
        {
            try
            {
                
                var client = new HttpClient();
                using (var response = await client.GetAsync("http://localhost:59930/medicinestockinformation"))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string stringData = response.Content.ReadAsStringAsync().Result;
                        _stockData = JsonConvert.DeserializeObject<List<MedicineStock>>(stringData);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        _stockData = null;
                    }
                    else
                    {
                        throw new Exception("Internal error in api called");
                    }
                }
                return _stockData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


    }
}
