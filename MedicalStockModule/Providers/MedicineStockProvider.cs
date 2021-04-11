using MedicineStockModule.Models;
using MedicineStockModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Providers
{
    public class MedicineStockProvider : IMedicineStockProvider
    {
        private readonly IMedicineStockRepository IMedicineStock;
        

        public MedicineStockProvider(IMedicineStockRepository IMedicineStock)
        {
            this.IMedicineStock = IMedicineStock;
        }
        public IEnumerable<MedicineStockDTO> GetMedicineStock()
        {
           
            var MedicineStockList = IMedicineStock.GetAll();
           
            return MedicineStockList.ToList();

        }
    }
}
