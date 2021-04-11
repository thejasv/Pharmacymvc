using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySupplyApp.Models;

namespace PharmacySupplyApp.Repositories
{
    public interface IRepScheduleRepo
    {
        public bool Add(RepScheduleDto repSchedule);
    }
}
