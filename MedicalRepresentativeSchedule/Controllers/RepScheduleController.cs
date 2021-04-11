
using MedicalRepresentativeSchedule.Models;
using MedicalRepresentativeSchedule.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace MedicalRepresentativeSchedule.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepScheduleController : ControllerBase
    {
        private readonly IRepScheduleProvider _repScheduleProvider;
       

        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RepScheduleController));
        public RepScheduleController(IRepScheduleProvider repSchedule)
        {
            this._repScheduleProvider = repSchedule;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string startDate)
        {
            try
            {
                var res = await _repScheduleProvider.GetRepScheduleAsync(startDate);
                if (res.Count!=0||res!=null)
                {
                    
                    return new OkObjectResult(res);
                }
                else
                {
                   
                    return NotFound("schedule not received");
                }
            }
            catch (Exception)
            {
                
                return StatusCode(500);
            }
        }
    }
}
