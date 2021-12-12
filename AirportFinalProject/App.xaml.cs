using Airport.Data;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.Services.FlightCreator;
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
        public static  ContextFactory _factory;
        private readonly Random _random;
        private readonly NavigationStore _navigationStore;
        private ProjectContext _context;
        private readonly IFlightCreator _creator;
        public App()
        {
            _factory = new ContextFactory(CONNECTION_STRING);
            _creator = new FlightCreator(_factory);
            _navigationStore = new NavigationStore();
            _random = new Random();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Server=DESKTOP-EKQUKID;Database=AirportData;Trusted_Connection=True;").Options;
            _context = new ProjectContext(options);
            _navigationStore.BaseViewModel = createFlightDataViewModel();
            _context.Database.Migrate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
        }
        private FlightDataViewModel createFlightViewModel()
        {
            return new FlightDataViewModel( new NavigationService( _navigationStore, createFlightDataViewModel), _random);
        }
        private CreateFlightViewModel createFlightDataViewModel()
        {
            return new CreateFlightViewModel(_creator, new NavigationService (_navigationStore, createFlightViewModel));
        }
    }
}
