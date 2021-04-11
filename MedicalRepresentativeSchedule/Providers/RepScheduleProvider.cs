using MedicalRepresentativeSchedule.Models;
using MedicalRepresentativeSchedule.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MedicalRepresentativeSchedule.Providers
{
    public class RepScheduleProvider : IRepScheduleProvider
    {
        private List<MedicineStock> _stockData=new List<MedicineStock>();
        private readonly List<DateTime> _dates = new List<DateTime>();
        private List<DoctorDTO> _docNames = new List<DoctorDTO>();
        private List<RepresentativeDetailsDTO> _repNames = new List<RepresentativeDetailsDTO>();
        private List<MedicineStock> _stock = new List<MedicineStock>();
        private readonly List<RepSchedule> _repSchedule = new List<RepSchedule>();
       
        private readonly IRepScheduleRepository _repScheduleRepository;
        private readonly IMedicineStockProvider _medicineStockProvider;

        public RepScheduleProvider(IRepScheduleRepository repScheduleRepository,IMedicineStockProvider medicineStockProvider)
        {
            _repScheduleRepository = repScheduleRepository;
            _medicineStockProvider = medicineStockProvider;
        }

        public List<DoctorDTO> GetDoctors()
        {
            try
            {
                
                return _repScheduleRepository.GetDoctorDetails();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<RepresentativeDetailsDTO> GetRepresentatives()
        {
            try
            {
                
                return _repScheduleRepository.GetRepresentativesDetails();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async Task<List<RepSchedule>> GetRepScheduleAsync(string startDate)
        {
            try
            {
                if (_dates.Count > 0)
                {
                    _dates.Clear();
                }
            
                DateTime start = Convert.ToDateTime(startDate);
                DateTime end = start.AddDays(6);
                int workDays = 0;
                while (start != end)
                {
                    if (start.DayOfWeek != DayOfWeek.Sunday)
                    {
                        _dates.Add(start);
                        workDays++;
                    }
                    if(workDays==5)
                    {
                        break;
                    }
                    start = start.AddDays(1);
                }
                _repNames = GetRepresentatives();
                _stock = await _medicineStockProvider.GetMedicineStock();
                _docNames = GetDoctors();
                if (_repNames==null|| _repNames.Count ==0  || _stock.Count==0 ||_stock==null|| _docNames.Count==0||_docNames==null)
                {
                    
                    return null;
                }
                for (var i=0;i<_dates.Count;i++)
                {
                    var rep = new RepSchedule
                    {
                        RepName = _repNames[(i % _repNames.Count)].RepresentativeName,
                        DoctorName = _docNames[i].Name,
                        TreatingAilment = _docNames[i].TreatingAilment,
                        MeetingSlot = "1pm-2pm",
                        DateOfMeeting = _dates[i].ToShortDateString()
                    };
                    var meds = (from s in _stock where s.TargetAilment.Contains(_docNames[i].TreatingAilment) select s.Name).ToList();
                    rep.Medicine = string.Join(",", meds);
                    rep.DoctorContactNumber = _docNames[i].ContactNumber;
                    _repSchedule.Add(rep);
                }
               
                return _repSchedule;
            }
            catch (Exception)
            {
               
                throw;
            }
        }
    }
}
