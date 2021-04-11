using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacySupplyApp.Models;
using PharmacySupplyApp.Providers;

namespace PharmacySupplyApp.Controllers
{
    public class ScheduleController : Controller
    {
       
        private readonly IRepScheduleProvider _repProvider;
        private string _token;
        public ScheduleController(IRepScheduleProvider repProvider)
        {
            _repProvider = repProvider;
        }

        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                    
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    
                    string today = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day;
                    ViewBag.Min = today;
                    return View();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(ScheduleDate dates)
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                    
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    _token = HttpContext.Session.GetString("token");
                    HttpResponseMessage response = await _repProvider.GetSchedule(dates.Date, _token);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        TempData["result"] = result;
                        return RedirectToAction("Schedule");
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        
                        return View("NoSchedule");
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        
                        return View("Unauthorized");
                    }
                    else
                    {
                        
                        return View("Error");
                    }
                }
            }
            catch (Exception)
            {
                
                return View("Error");
            }
        }

        public IActionResult Schedule()
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                    
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    List<RepSchedule> schedules =
                        JsonConvert.DeserializeObject<List<RepSchedule>>(TempData["result"].ToString());
                    _repProvider.AddToDb(schedules);
                    return View(schedules);
                }
            }
            catch (Exception)
            {
                
                return View("Error");
            }
        }
    }
}