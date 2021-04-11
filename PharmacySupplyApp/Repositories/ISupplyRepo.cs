using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySupplyApp.Models;

namespace PharmacySupplyApp.Repositories
{
    public interface ISupplyRepo
    {
        public bool Add(SupplyDto supply);
    }
}
