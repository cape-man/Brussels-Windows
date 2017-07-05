using Brussels.FlightSearch.Abstract;
using Brussels.FlightSearch.Entity.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brussels.FlightSearch.Service
{
    public class FlightDatabase
    {
        SQLiteAsyncConnection database;

        public FlightDatabase(string dbPath)
        {
            //Todo: Copy the DB to Local on init or create the DB from JSON
            database = new SQLiteAsyncConnection(dbPath);
            //dataService.CreateTableAsync<TodoItem>().Wait()
        }

        public Task<List<Flight>> GetItemsAsync()
        {
            return database.Table<Flight>().ToListAsync();
        }

        public async Task CreateDB(FlightDetail flightDetail)
        {
            await database.CreateTableAsync<Flight>();
            await database.CreateTableAsync<FlightSchedule>();
            await Task.Delay(1000);
            
            await database.InsertAllAsync(flightDetail.Flights);
            await database.InsertAllAsync(flightDetail.FlightSchedules);
            await Task.Delay(1000);
        }

        public Task<List<Flight>> GetAllFlight()
        {
            return database.Table<Flight>().ToListAsync();

        }

        public Task<List<FlightSchedule>> GetFlightSchedule(int flightId)
        {
            return database.Table<FlightSchedule>().Where(e => e.FlightId == flightId).ToListAsync();
        }

        public Task<List<FlightSchedule>> GetAllFlightSchedule()
        {
            return database.Table<FlightSchedule>().ToListAsync();
        }
    }
}
