using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Entity
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineCode { get; set; }
        public string FlightNumber { get; set; }
        public string IconPath { get; set; }

        public string AircraftType { get; set; }
        public string FlightFullname { get { return AirlineCode + FlightNumber; } }

        public FlightScheduleInfo FlightSchedule { get; set; }
    }

    public class FlightScheduleInfo
    {
        public int FlightScheduleId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string DepartureAirportCode { get; set; }
        public string DepartureCityName { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string ArrivalCityName { get; set; }
        public string FlightStatus { get; set; }
        public DateTime ScheduledDepatureDateTime { get; set; }
        public DateTime ScheduledArrivalDateTime { get; set; }
        public DateTime EstimatedDepartureDateTime { get; set; }
        public DateTime EstimatedArrivalDateTime { get; set; }
        public DateTime ActualDepatureDateTime { get; set; }
        public DateTime ActualArrivalDateTime { get; set; }
        public string DepartureCountryName { get; set; }
        public string ArrivalCountryName { get; set; }
        public string DepartureGateNumber { get; set; }
        public string BaggageBeltNumber { get; set; }
        public int FlightId { get; set; }

        public TimeSpan FlightTime
        {
            get
            {
                return ScheduledArrivalDateTime - ScheduledDepatureDateTime;
            }
        }
    }
}
