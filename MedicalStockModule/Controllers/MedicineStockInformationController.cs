using MedicineStockModule.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;



namespace MedicineStockModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineStockInformationController : Controller
    {
        //creating provider layer interface object
        private readonly IMedicineStockProvider iMedicineStock;
        public MedicineStockInformationController(IMedicineStockProvider iMedicineStock)
        {
            this.iMedicineStock = iMedicineStock;
        }

        //hhtp get method to get all the medicine stock list 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res =iMedicineStock.GetMedicineStock();
                
                if (res != null)
                { 
                    
                    return Ok(res.ToList());
                }
               
                return Content("No such details found please try again.");
            }
            catch(Exception e)
            {
               
                return Content("The following exception has occurred while retreving the stock." + e.Message + " Please try again");
            }
        }
    }
}
