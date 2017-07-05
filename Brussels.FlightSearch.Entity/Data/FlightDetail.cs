using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Entity.Data
{
    public class FlightDetail
    {
        public List<Flight> Flights { get; set; }
        public List<FlightSchedule> FlightSchedules { get; set; }
    }
}
