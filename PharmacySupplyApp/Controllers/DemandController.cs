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
    public class DemandController : Controller
    {
     
        private readonly IDemandProvider _demandProvider;
        private HttpResponseMessage _response;
        private string _token;

        public DemandController(IDemandProvider demandProvider)
        {
            _demandProvider = demandProvider;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                   
                    return RedirectToAction("Login", "User");
                }
                else
                {
                   
                    _response = await _demandProvider.GetStock();
                    if(_response.IsSuccessStatusCode)
                    {
                       
                        var result = await _response.Content.ReadAsStringAsync();
                        List<MedicineStock> stocks = JsonConvert.DeserializeObject<List<MedicineStock>>(result);
                        List<MedicineDemand> demands = _demandProvider.GetDemand(stocks);
                        return View(demands);
                    }
                    else if(_response.StatusCode==HttpStatusCode.NotFound)
                    {
                        
                        return View("NoSupply");
                    }
                    else if(_response.StatusCode==HttpStatusCode.Unauthorized)
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

        [HttpPost]
        public async Task<IActionResult> Index(IEnumerable<MedicineDemand> demands)
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
                    _response = await _demandProvider.GetSupply(demands.ToList(),_token);
                    if (_response.IsSuccessStatusCode)
                    {
                        
                        var result = await _response.Content.ReadAsStringAsync();
                        TempData["supply"] = result;
                        return RedirectToAction("DisplaySupply");
                    }
                    else if(_response.StatusCode==HttpStatusCode.NotFound)
                    {
                       
                        return View("NoSupply");
                    }
                    else if (_response.StatusCode == HttpStatusCode.Unauthorized)
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

        public IActionResult DisplaySupply()
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                  
                    return RedirectToAction("Login", "User");
                }
                else
                {
                   
                    List<Supply> supplies = JsonConvert.DeserializeObject<List<Supply>>(TempData["supply"].ToString());
                    _demandProvider.AddSupplyToDB(supplies);
                    return View(supplies.OrderBy(s => s.PharmacyName));
                }
            }
            catch (Exception)
            {
                
                return View("Error");
            }
        }
    }
}