using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Brussels.FlightSearch.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Brussels.FlightSearch.UWP
{
    public sealed partial class UWPFlightStatusView : UserControl
    {
        public UWPFlightStatusView()
        {
            this.InitializeComponent();            
        }

        private Flight flight;
        public Flight Flight
        {
            get
            {
                if (flight == null)
                    flight = new Flight();

                return flight;
            }
            set
            {
                flight = value;
                OnFlightPropertyChanged();
            }
        }

        private void OnFlightPropertyChanged()
        {
            if(flight.FlightSchedule != null)
            {
                tbScheduledTime.Text = flight.FlightSchedule.ScheduledDepatureDateTime.ToString("H:mm");

                tbActualTime.Text = flight.FlightSchedule.ActualDepatureDateTime.ToString("H:mm");

                tbDepartureAirportCode.Text = string.IsNullOrEmpty(flight.FlightSchedule.DepartureAirportCode) ? string.Empty : flight.FlightSchedule.DepartureAirportCode;

                tbDepartureCityName.Text = string.IsNullOrEmpty(flight.FlightSchedule.DepartureCityName) ? string.Empty : flight.FlightSchedule.DepartureCityName;

                tbFlightTime.Text = flight.FlightSchedule.FlightTime.ToString("%h\\:mm");

                tbScheduledArrivalTime.Text = flight.FlightSchedule.ScheduledArrivalDateTime.ToString("H.mm");

                tbActualArrivalTime.Text = flight.FlightSchedule.ActualArrivalDateTime.ToString("H.mm");

                tbArrivalAirportCode.Text = string.IsNullOrEmpty(flight.FlightSchedule.ArrivalAirportCode) ? string.Empty : flight.FlightSchedule.ArrivalAirportCode;

                tbArrivalCityName.Text = string.IsNullOrEmpty(flight.FlightSchedule.ArrivalCityName) ? string.Empty : flight.FlightSchedule.ArrivalCityName;
            }
            
        }       
    }
}
