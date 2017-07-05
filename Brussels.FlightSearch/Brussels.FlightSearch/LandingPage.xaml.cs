using Brussels.FlightSearch.Entity;
using Brussels.FlightSearch.Model;
using Brussels.FlightSearch.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brussels.FlightSearch
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        private DataService flightService;
        FlightSearchModel flightSearchModel;

        public LandingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            flightService = new DataService();
            flightSearchModel = new FlightSearchModel();
            flightSearchModel.GetFlightList().ContinueWith(task => BindFlightDetails(), TaskContinuationOptions.AttachedToParent);
        }

        private void BindFlightDetails()
        {
            if (flightSearchModel.FlightList != null && flightSearchModel.FlightList.Count > 0)
            {
                CurrentFlight.Instance.AirlineList = flightSearchModel.FlightList;
            }
        }

        private async void TileFlightStatus_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
