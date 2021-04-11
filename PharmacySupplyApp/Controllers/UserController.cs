using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacySupplyApp.Models;
using PharmacySupplyApp.Providers;

namespace PharmacySupplyApp.Controllers
{
    public class UserController : Controller
    {
      
        private readonly IUserProvider _userProvider;

        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                    
                    return RedirectToAction("Login");
                }
                else
                {
                    
                    return View();
                }
            }
            catch (Exception)
            {
               
                return View("Error");
            }
        }
        public IActionResult Login()
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    return View();
                }
            }
            catch (Exception)
            {
               
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User credentials)
        {
            try
            {
                HttpResponseMessage response = await _userProvider.Login(credentials);
                if (response.IsSuccessStatusCode)
                {
                   
                    var result = await response.Content.ReadAsStringAsync();
                    JWT token = JsonConvert.DeserializeObject<JWT>(result);
                    HttpContext.Session.SetString("token", token.Token);
                    HttpContext.Session.SetString("userName", credentials.UserName);
                    ViewBag.UserName = credentials.UserName;
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    
                    ViewBag.Info = "Invalid username/password";
                    return View();
                }
                else
                {
                    
                    return View("Error");
                }
            }
            catch (Exception)
            {
                
                return View("Error");
            }
        }
        public IActionResult Logout()
        {
            try
            {
               
                HttpContext.Session.Remove("token");
                HttpContext.Session.Remove("userName");
                return View();
            }
            catch (Exception)
            {
                
                return View("Error");
            }
        }

        public IActionResult Contact()
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                    
                    return RedirectToAction("Login");
                }
                else
                {
                  
                    return View("Contact");
                }
            }
            catch (Exception)
            {
              
                return View("Error");
            }
        }
    }
}