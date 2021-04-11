using PharmacySupplyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySupplyApp.Data;
using PharmacySupplyApp.Repositories;

namespace PharmacySupplyApp.Repositories
{
    public class SupplyRepo : ISupplyRepo
    {
        private PMSContext _context;
        public SupplyRepo(PMSContext context)
        {
            _context = context;
        }
        public bool Add(SupplyDto supply)
        {
            _context.Add(supply);
            _context.SaveChanges();
            return true;
        }
    }
}
