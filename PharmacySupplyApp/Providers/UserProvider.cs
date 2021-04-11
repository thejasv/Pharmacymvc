using PharmacySupplyApp.Models;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacySupplyApp.Helpers;

namespace PharmacySupplyApp.Providers
{
    public class UserProvider : IUserProvider
    {
        
        private readonly HttpClient _httpClient;

        public UserProvider(IClient authClient)
        {
            _httpClient = authClient.GetAuthClient();
        }
        public async Task<HttpResponseMessage> Login(User credentials)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:59415");
                StringContent content = new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("User/Login", content);
                return response;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
