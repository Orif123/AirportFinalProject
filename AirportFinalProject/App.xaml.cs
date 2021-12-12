using Airport.Data;
using Airport.Models;
using AirportFinalProject.Data;
using AirportFinalProject.Services.FlightService;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Stores;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace AirportFinalProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private  FlightDataViewModel _flightDataViewModel;
        private const string CONNECTION_STRING = "Server=DESKTOP-EKQUKID;Database=AirportData;Trusted_Connection=True;";
        private readonly NavigationStore _navigationStore;
        private ProjectContext _context;
        private readonly IFlightProvider _provider;
        private readonly IFlightCreator _creator;
        private readonly ContextFactory _factory;

        public App()
        {
            _context = new ProjectContext();
            _flightDataViewModel = new FlightDataViewModel(new NavigationService(_navigationStore, createFlightDataViewModel), _creator, _provider, _context);
            _factory = new ContextFactory(CONNECTION_STRING);
            _provider = new FlightsProvider(_factory);
            _creator = new FlightCreator(_factory);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;
            using (_context = new ProjectContext(options))
            {
                
                _context.Database.Migrate();
            }
            _navigationStore.BaseViewModel = createFlightDataViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            RandomFlight();
        }
        public string GetFlyNumber(string flightId, string companyId)
        {
            using (ProjectContext context = _factory.CreateDBContext())
            {
                var company = context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
                var name = company.CompanyName.ToUpper().Substring(0, 3);
                var flight = flightId.Substring(0, 4);
                var flyNumber = $"{name}-{flight}";
                return flyNumber;
            }
        }
        public string GetCompanyId(Random rnd)
        {
            using (ProjectContext context = _factory.CreateDBContext())
            {
                var index = rnd.Next(context.Companies.ToArray().Length);
                var company = context.Companies.Select(p => p.CompanyId).ToArray()[index];
                return company;
            }
        }
        private FlightDataViewModel createFlightViewModel()
        {
            return new FlightDataViewModel(new NavigationService(_navigationStore, createFlightDataViewModel), _creator, _provider, _context);
        }
        private CreateFlightViewModel createFlightDataViewModel()
        {
            return new CreateFlightViewModel(_creator, new NavigationService(_navigationStore, createFlightViewModel));
        }
        public void RandomFlight()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 5);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            using (ProjectContext _context = _factory.CreateDBContext())
            {
                Random _rnd = new Random();
                var flight = new Flight()
                {
                    FlightId = RandomGenerator.GetFlightId(),
                    CompanyId = GetCompanyId(_rnd),
                    IsDeparture = RandomGenerator.IsDeparture(_rnd),
                    FlightDate = DateTime.Now
                };
                flight.FlightNumber = GetFlyNumber(flight.FlightId, flight.CompanyId);
                if (flight.IsDeparture)
                {
                    flight.StationId = 1;

                }
                else if (!flight.IsDeparture)
                {
                    flight.StationId = 9;
                }

                Progress(_context);
                _context.Flights.Add(flight);
                _context.SaveChanges();
               _flightDataViewModel.UpdateFlights();
            }
        }
        private void Progress(ProjectContext context)
        {
            foreach (var flight in context.Flights)
            {
                if (flight.IsDeparture)
                {
                    ++flight.StationId;
                    if (flight.StationId > 5)
                    {
                        context.Flights.Remove(flight);
                    }
                }
                else if (!flight.IsDeparture)
                {

                    --flight.StationId;
                    if (flight.StationId < 5)
                    {
                        context.Flights.Remove(flight);
                    }
                }
            }
        }
       
    }
    public static class RandomGenerator
    {
       

        public static string GetFlightId()
        {
            var flightId = Guid.NewGuid().ToString();
            return flightId;
        }

        public static bool IsDeparture(Random rnd)
        {
            bool randomBool = rnd.Next(0, 2) > 0;
            return randomBool;
        }
    }
}
