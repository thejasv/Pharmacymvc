using MedicineStockModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Repository
{
    public class MedicineStockRepository:IMedicineStockRepository
    {
        

        private static readonly List<MedicineStockDTO> MedicineStockInformation = new List<MedicineStockDTO>() {
           new MedicineStockDTO
            {
                Name = "Ibuprofen",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "Orthopaedics",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Aceclofenac",
                ChemicalComposition = new List<string> { "chemical3", "chemical2" },
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("10-09-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Ibuprofin",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "Gynaecology",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Oxytocin",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "Gynaecology",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Paracetamol",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },


        };
        
        public IEnumerable<MedicineStockDTO> GetAll()
        {
            
            var MedicineStocklist = from Medicine in MedicineStockInformation where Medicine.NumberOfTabletsInStock>0 select Medicine;
            return MedicineStocklist.ToList();
           
        }
    }
}
