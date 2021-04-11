using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Models;
using AuthService.Provider;
using AuthService.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class UserController : ControllerBase
    {
       
        private readonly IUserProvider _userProvider;
        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        
        [HttpPost]
        public IActionResult Login(User userCred)
        {
            
            try
            {
                string token = _userProvider.Login(userCred);
                if (token != null)
                {
                    
                    return Ok(new { token });
                }
                else
                {
                  
                    return NotFound("invalid username/password");
                }
            }
            catch (Exception)
            {
                
                return StatusCode(500);
            }
        }
    }
}
