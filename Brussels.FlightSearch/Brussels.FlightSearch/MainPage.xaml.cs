using Brussels.FlightSearch.Entity;
using Brussels.FlightSearch.Model;
using Brussels.FlightSearch.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brussels.FlightSearch
{
    public partial class MainPage : ContentPage
    {
        private DataService flightService;
        FlightSearchModel flightSearchModel;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            flightService = new DataService();
            flightSearchModel = new FlightSearchModel();

            flightSearchModel.StartDate = DateTime.Now.Date;
            flightSearchModel.FlightList = CurrentFlight.Instance.AirlineList;
            BindingContext = flightSearchModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(await flightSearchModel.GetFlightDetails(flightSearchModel.SelectedAirline.AirlineCode, flightSearchModel.SelectedAirline.FlightNumber))
            {
                CurrentFlight.Instance.SelectedFlight = flightSearchModel.SelectedFlight;
                CurrentFlight.Instance.SelectedDate = DateTime.Today;

                await Navigation.PushAsync(new SearchResultPage());
            }
            else
            {
                await DisplayAlert("Alert", "No Flights Found","OK");
            }
        }


        private void Date_Focused(object sender, FocusEventArgs e)
        {
            StartDatePicker.IsVisible = true;
            StartDatePicker.DateSelected += DatePicker_DateSelected;
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            flightSearchModel.StartDate = e.NewDate;
            StartDatePicker.IsVisible = false;
            
            //StartDateText.Text = flightSearchModel.StartDate.ToString("d");
        }

        private async void BackButton_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
