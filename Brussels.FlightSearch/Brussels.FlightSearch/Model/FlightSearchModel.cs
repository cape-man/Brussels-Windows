using Brussels.FlightSearch.Entity;
using Brussels.FlightSearch.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Model
{
    public class FlightSearchModel : ModelBase
    {

        private DataService flightDataService;
        private Flight selectedFlight;

        private List<Flight> flightList = new List<Flight>();
        private Flight selectedAirline = new Flight();
        private DateTime startDate;

        public FlightSearchModel()
        {
            flightDataService = new DataService();
        }

        #region Bindable Properties

        public Flight SelectedAirline
        {
            get
            {
                if (selectedAirline == null)
                    return new Flight();
                return selectedAirline;
            }
            set
            {
                if (selectedAirline != null)
                    selectedAirline = new Flight();
                selectedAirline = value;

                RaisePropertyChanged("SelectedAirline");
            }
        }

        public List<Flight> emptyFlightList()
        {
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight() { AirlineName = "", AirlineCode = "" });
            return flights;
        }

        public List<Flight> FlightList
        {
            get
            {
                if (flightList == null)
                    return emptyFlightList();
                return flightList;
            }
            set
            {
                flightList = value;
                RaisePropertyChanged("FlightList");
            }
        }

        public DateTime StartDate
        {
            get
            {
                if (startDate == null)
                    return DateTime.Now.Date;
                return startDate;
            }
            set
            {
                if (startDate != value)
                    startDate = DateTime.Now.Date;
                startDate = value;

                RaisePropertyChanged("StartDate");
            }
        }

        private string flightModel;

        public string FlightModel
        {
            get
            {
                return flightModel;
            }
            set
            {
                flightModel = value;
                RaisePropertyChanged("FlightModel");
            }
        }

        public Flight SelectedFlight
        {
            get
            {
                if (selectedFlight == null)
                {
                    selectedFlight = new Flight();
                    selectedFlight.FlightSchedule = new FlightScheduleInfo();
                }
                return selectedFlight;
            }
            set
            {
                selectedFlight = value;
                RaisePropertyChanged("SelectedFlight");
            }
        }

        private DateTime selectedDateTime;

        public DateTime SelectedDatetime
        {
            get { return selectedDateTime; }
            set
            {
                selectedDateTime = value;
                RaisePropertyChanged("SelectedDatetime");
            }
        }

        //private List<FlightScheduleInfo> flightSchedules;

        public FlightScheduleInfo FlightSchedule
        {
            get
            {
                if (selectedFlight == null)
                    selectedFlight = new Flight();
                if (selectedFlight.FlightSchedule == null)
                    selectedFlight.FlightSchedule = new FlightScheduleInfo();
                return selectedFlight.FlightSchedule;
            }
            set
            {
                selectedFlight.FlightSchedule = value;
                RaisePropertyChanged("FlightSchedules");
                RaisePropertyChanged("SelectedFlight");
            }
        }


        #endregion

        #region Service methods

        public async Task GetFlightSchedule(Flight flight, DateTime datetime)
        {
            if (flight != null)
            {
                FlightSchedule = (await flightDataService.GetScheduleByFlight(flight)).FirstOrDefault();

                flight.FlightSchedule = FlightSchedule;

                SelectedFlight = flight;
                SelectedDatetime = datetime;

            }
        }

        public async Task GetFlightList()
        {
            var DistinctFlightList = await flightDataService.GetAllFlight();
            if (DistinctFlightList != null)
            {
                FlightList = DistinctFlightList.GroupBy(e => new { e.AirlineCode, e.AirlineName }).Select(e => new Flight() { AirlineName = e.Key.AirlineName, AirlineCode = e.Key.AirlineCode }).ToList();
            }
        }

        public async Task<bool> GetFlightDetails(string airlineCode, string flightNumber)
        {
            bool result = true;

            var AllFlightList = await flightDataService.GetAllFlight();
            if (AllFlightList != null)
            {
                var flight = AllFlightList.Where(e => e.AirlineCode == airlineCode && e.FlightNumber == flightNumber).FirstOrDefault();
                if(flight != null)
                {
                    SelectedFlight = flight;
                }
                else
                {
                    result = false;
                }                
            }
            return result;
        }

        #endregion
    }
}
