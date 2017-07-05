using Brussels.FlightSearch.Entity;

using Brussels.FlightSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brussels.FlightSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentPage
    {
        FlightSearchModel flightSearchModel;

        List<FlightScheduleInfo> FlightSchedules = new List<FlightScheduleInfo>();
        public SearchResultPage()
        {
            InitializeComponent();
            FlightSchedules.Add(new FlightScheduleInfo() { FlightScheduleId = 10 });
            NavigationPage.SetHasNavigationBar(this, false);
           
            flightSearchModel = new FlightSearchModel();

            //BindingContext = this;
            BindingContext = flightSearchModel;

            //flightSearchModel.SelectedFlight = CurrentFlight.Instance.SelectedFlight;

            //Load Schedule for the selectedFlight and Date
            flightSearchModel.GetFlightSchedule(CurrentFlight.Instance.SelectedFlight, CurrentFlight.Instance.SelectedDate).ContinueWith((result) => { });
        }

        private void BackButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}