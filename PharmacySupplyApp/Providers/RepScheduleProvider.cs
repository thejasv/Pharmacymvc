using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PharmacySupplyApp.Helpers;
using PharmacySupplyApp.Models;
using PharmacySupplyApp.Repositories;

namespace PharmacySupplyApp.Providers
{
    public class RepScheduleProvider : IRepScheduleProvider
    {
        
        private readonly IRepScheduleRepo _repScheduleRepo;
        private readonly HttpClient _httpClient;

        public RepScheduleProvider(IRepScheduleRepo repScheduleRepo,IClient medRepClient)
        {
            _repScheduleRepo = repScheduleRepo;
            _httpClient = medRepClient.GetMedRepClient();
        }

        public void AddToDb(List<RepSchedule> schedule)
        {
            try
            {
                foreach (var s in schedule)
                {
                    RepScheduleDto repSchedule = new RepScheduleDto(){DateOfMeeting = s.DateOfMeeting,DoctorContactNumber = s.DoctorContactNumber,DoctorName = s.DoctorName,Medicine = s.Medicine,MeetingSlot = s.MeetingSlot,RepName = s.RepName,TreatingAilment = s.TreatingAilment};
                  
                    _repScheduleRepo.Add(repSchedule);
                }
            }
            catch (Exception)
            {
               
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetSchedule(DateTime startDate,string token)
        {
            try
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                _httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                string s = (startDate.Day).ToString() + startDate.ToString("MMM") + (startDate.Year).ToString();
                var response = await _httpClient.GetAsync("api/RepSchedule?startdate=" + s);
                
                return response;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
