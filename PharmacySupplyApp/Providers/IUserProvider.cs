using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PharmacySupplyApp.Models;

namespace PharmacySupplyApp.Providers
{
    public interface IUserProvider
    {
        public Task<HttpResponseMessage> Login(User credentials);
    }
}
