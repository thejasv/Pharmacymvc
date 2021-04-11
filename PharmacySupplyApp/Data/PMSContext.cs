using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacySupplyApp.Models;

namespace PharmacySupplyApp.Data
{
    public class PMSContext : DbContext
    {
        public PMSContext(DbContextOptions<PMSContext> options) : base(options)
        {

        }

        public DbSet<RepScheduleDto> Schedule { get; set; }
        public DbSet<SupplyDto> Supplies { get; set; }
    }
}
