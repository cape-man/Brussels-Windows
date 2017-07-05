using Brussels.FlightSearch.Abstract;
using Brussels.FlightSearch.Entity;
using Brussels.FlightSearch.Entity.Data;
using Brussels.FlightSearch.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brussels.FlightSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            Task.Run(async () =>
            {
                await copyFlightSceduleIfNeeded();

            }).Wait();

            MainPage = new NavigationPage(new Brussels.FlightSearch.LandingPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts


        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async Task copyFlightSceduleIfNeeded()
        {
            IFileHelper fileHelper = DependencyService.Get<IFileHelper>();

            //Check if DB exist
            string DBFilePath = fileHelper.GetLocalFilePath(Constants.BrusselsDBFileName);

            if (!fileHelper.IsFileExist(DBFilePath))
            {
                DataService dataservice = new DataService();
                //If DB not exist read JSON
                string json = fileHelper.ReadFile(Constants.FlightDetailsJSONFileName);

                //Convert json to Data entity
                var flightDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<FlightDetail>(json);


                //Create new DB with data entity values 
               await dataservice.CreateDB(flightDetail);
            }
        }
    }
}
