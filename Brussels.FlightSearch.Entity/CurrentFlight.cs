using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Entity
{
    /// <summary>
    /// Class to hold/pass data across application pages
    /// </summary>
    public class CurrentFlight
    {
        #region Singleton Implementation

        private static volatile CurrentFlight instance;
        private static object syncRoot = new Object();



        public static CurrentFlight Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CurrentFlight();
                    }
                }

                return instance;
            }
        }

        #endregion

        private CurrentFlight()
        {
            Reset();
        }
        public Flight SelectedFlight { get; set; }

        public List<Flight> AirlineList { get; set; }
        public FlightScheduleInfo SelectedFlightSchedule { get; set; }
        public DateTime SelectedDate { get; set; }

        public void Reset()
        {
            SelectedFlight = new Flight();
            SelectedFlightSchedule = new FlightScheduleInfo();
        }
    }
}
