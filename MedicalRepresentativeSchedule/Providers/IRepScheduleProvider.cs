using MedicalRepresentativeSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.Providers
{
    public interface IRepScheduleProvider
    {
        public  Task<List<RepSchedule>> GetRepScheduleAsync(string startdate);
        public List<DoctorDTO> GetDoctors();
        public List<RepresentativeDetailsDTO> GetRepresentatives();
     
    }
}
