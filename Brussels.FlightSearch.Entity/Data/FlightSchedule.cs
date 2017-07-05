using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Entity.Data
{
    public class FlightSchedule
    {
        public int FlightScheduleId { get; set; }
        public string DepartureDateTime { get; set; }
        public string DepartureAirportCode { get; set; }
        public string DepartureCityName { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string ArrivalCityName { get; set; }
        public string FlightStatus { get; set; }
        public string ScheduledDepatureDateTime { get; set; }
        public string ScheduledArrivalDateTime { get; set; }
        public string EstimatedDepartureDateTime { get; set; }
        public string EstimatedArrivalDateTime { get; set; }
        public string ActualDepatureDateTime { get; set; }
        public string ActualArrivalDateTime { get; set; }
        public string DepartureCountryName { get; set; }
        public string ArrivalCountryName { get; set; }
        public string DepartureGateNumber { get; set; }
        public string BaggageBeltNumber { get; set; }
        public int FlightId { get; set; }
    }
}
