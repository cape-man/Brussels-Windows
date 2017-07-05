using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Entity.Data
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineCode { get; set; }
        public string FlightNumber { get; set; }
        public string IconPath { get; set; }

        public string AircraftType { get; set; }
    }
}
