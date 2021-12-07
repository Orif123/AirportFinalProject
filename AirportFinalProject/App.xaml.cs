using Airport.Data;
using AirportFinalProject.Data;
using AirportFinalProject.Services.FlightService;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Stores;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace AirportFinalProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-EKQUKID;Database=AirportData;Trusted_Connection=True;";
        private readonly Random _random;
        private readonly NavigationStore _navigationStore;
        private ProjectContext _context;
        private readonly IFlightProvider _provider;
        private readonly IFlightCreator _creator;

        public App()
        {
            ContextFactory _factory = new ContextFactory(CONNECTION_STRING);
            _provider = new FlightsProvider(_factory, createFlightViewModel());
             _creator = new FlightCreator(_factory, createFlightViewModel());
            _navigationStore = new NavigationStore();
            _random = new Random();
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
        }
        private FlightDataViewModel createFlightViewModel()
        {
            return new FlightDataViewModel(new NavigationService(_navigationStore, createFlightDataViewModel), _creator, _provider, _random, createFlightDataViewModel());
        }
        private CreateFlightViewModel createFlightDataViewModel()
        {
            return new CreateFlightViewModel(_creator, new NavigationService(_navigationStore, createFlightViewModel));
        }
    }
}
