using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacySupplyApp.Models
{
    public class ScheduleDate
    {
        [Required(ErrorMessage = "Please choose a date")]
        public DateTime Date { get; set; }
    }
}
