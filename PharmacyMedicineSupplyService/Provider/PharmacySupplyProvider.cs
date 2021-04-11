using Newtonsoft.Json;
using PharmacyMedicineSupplyService.Models;
using PharmacyMedicineSupplyService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Provider
{
    public class PharmacySupplyProvider : IPharmacySupplyProvider
    {
        private readonly ISupplyRepo supplyRepo;
        private List<PharmacyDTO> pharmacies;
        private readonly IMedicineStockProvider stockProvider;
        private readonly List<PharmacyMedicineSupply> pharmacySupply = new List<PharmacyMedicineSupply>();
        

        public PharmacySupplyProvider(ISupplyRepo repo, IMedicineStockProvider provider)
        {
            supplyRepo = repo;
            stockProvider = provider;
        }
        public async Task<List<PharmacyMedicineSupply>> GetSupply(List<MedicineDemand> medicines)
        {
            pharmacies = supplyRepo.GetPharmacies();
            
            foreach (var m in medicines)
            {
                if (m.Count > 0)
                {
                    int stockCount = await stockProvider.GetStock(m.MedicineName);
                    if (stockCount != -1)
                    {
                        if (stockCount < m.Count)
                            m.Count = stockCount;
                        int indSupply = (m.Count) / pharmacies.Count;
                        foreach (var i in pharmacies)
                        {
                            pharmacySupply.Add(new PharmacyMedicineSupply { MedicineName = m.MedicineName, PharmacyName = i.pharmacyName, SupplyCount = indSupply });
                        }
                        if (m.Count > indSupply * pharmacies.Count)
                        {
                            pharmacySupply[pharmacySupply.Count - 1].SupplyCount += (m.Count - indSupply * pharmacies.Count);
                        }
                    }
                }

            }
            
            return pharmacySupply;

        }

    }
}