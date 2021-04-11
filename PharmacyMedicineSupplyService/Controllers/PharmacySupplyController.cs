using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupplyService.Models;
using PharmacyMedicineSupplyService.Provider;
using PharmacyMedicineSupplyService.Repository;

namespace PharmacyMedicineSupplyService.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PharmacySupplyController : ControllerBase
    {
        private readonly IPharmacySupplyProvider _provider;
        
        public PharmacySupplyController(IPharmacySupplyProvider provider)
        {
            _provider = provider;
        }
        [HttpPost("Get")]
        public async Task<IActionResult> Get(List<MedicineDemand> m)
        {
            try
            {
                var res = await _provider.GetSupply(m);
                if(res.Count>0)
                {
                    
                    return Ok(res);
                }
                
                return NotFound("No such details found please try again.");
            }
            catch(Exception )
            {
               
                return StatusCode(500);
            }

            
        }
    }
}
