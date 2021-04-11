using MedicalRepresentativeSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.Repositories
{
    public interface IRepScheduleRepository
    {
        public List<DoctorDTO> GetDoctorDetails();
        public List<RepresentativeDetailsDTO> GetRepresentativesDetails();
    }
}
