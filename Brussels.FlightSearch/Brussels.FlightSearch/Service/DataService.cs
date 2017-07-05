using Brussels.FlightSearch.Abstract;
using Brussels.FlightSearch.Entity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brussels.FlightSearch.Service
{
    public class DataService
    {
        private static FlightDatabase database;

        static DataService()
        {
            if (database == null)
            {
                database = new FlightDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath(Constants.BrusselsDBFileName));
            }
        }
        //public static FlightDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new FlightDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("BrusselsDB.db"));
        //        }
        //        return database;
        //    }
        //}

        public async Task CreateDB(Entity.Data.FlightDetail flightDetail)
        {
           await database.CreateDB(flightDetail);
        }

        public async Task<List<Flight>> GetAllFlight()
        {
            List<Flight> flights = default(List<Flight>);
            var dataFlights = await database.GetAllFlight();

            if (dataFlights != null && dataFlights.Count > 0)
            {
                flights = new List<Flight>();

                foreach (var flight in dataFlights)
                {
                    flights.Add(new Flight()
                    {
                        FlightId = flight.FlightId,
                        AirlineCode = flight.AirlineCode,
                        AirlineName = flight.AirlineName,
                        FlightNumber = flight.FlightNumber,
                        AircraftType = flight.AircraftType,
                        IconPath = flight.IconPath
                    });
                }
            }

            return flights;
        }


        public async Task<List<FlightScheduleInfo>> GetScheduleByFlight(Flight flight)
        {
            List<FlightScheduleInfo> flightSchedules = default(List<FlightScheduleInfo>);

            var dataFlightSchedule = await database.GetFlightSchedule(flight.FlightId);

            if (dataFlightSchedule != null)
            {
                flightSchedules = new List<FlightScheduleInfo>();

                foreach (var schedule in dataFlightSchedule)
                {
                    FlightScheduleInfo flightSchedule = new FlightScheduleInfo();

                    DateTime datetime = new DateTime();
                    flightSchedule.ActualArrivalDateTime = DateTime.TryParse(schedule.ActualArrivalDateTime, out datetime) ? datetime : default(DateTime);
                    flightSchedule.ActualDepatureDateTime = DateTime.TryParse(schedule.ActualDepatureDateTime, out datetime) ? datetime : default(DateTime);
                    flightSchedule.DepartureDateTime = DateTime.TryParse(schedule.DepartureDateTime, out datetime) ? datetime : default(DateTime);

                    flightSchedule.EstimatedArrivalDateTime = DateTime.TryParse(schedule.EstimatedArrivalDateTime, out datetime) ? datetime : default(DateTime);

                    flightSchedule.EstimatedDepartureDateTime = DateTime.TryParse(schedule.EstimatedDepartureDateTime, out datetime) ? datetime : default(DateTime);

                    flightSchedule.ScheduledArrivalDateTime = DateTime.TryParse(schedule.ScheduledArrivalDateTime, out datetime) ? datetime : default(DateTime);

                    flightSchedule.ScheduledDepatureDateTime = DateTime.TryParse(schedule.ScheduledDepatureDateTime, out datetime) ? datetime : default(DateTime);

                    flightSchedule.ArrivalAirportCode = schedule.ArrivalAirportCode;
                    flightSchedule.ArrivalCityName = schedule.ArrivalCityName;
                    flightSchedule.ArrivalCountryName = schedule.ArrivalCountryName;
                    flightSchedule.BaggageBeltNumber = schedule.BaggageBeltNumber;
                    flightSchedule.DepartureAirportCode = schedule.DepartureAirportCode;
                    flightSchedule.DepartureCityName = schedule.DepartureCityName;
                    flightSchedule.DepartureCountryName = schedule.DepartureCountryName;
                    flightSchedule.DepartureGateNumber = schedule.DepartureGateNumber;
                    flightSchedule.FlightId = schedule.FlightId;
                    flightSchedule.FlightScheduleId = schedule.FlightScheduleId;
                    flightSchedule.FlightStatus = schedule.FlightStatus;                    

                    flightSchedules.Add(flightSchedule);
                }
            }

            return flightSchedules;
        }
    }
}
