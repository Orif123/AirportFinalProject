using Airport.Data;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.Services.FlightCreator;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Stores;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using System.Windows.Controls;

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
            _navigationStore.BaseViewModel = createSimulatorViewModel();
            _context.Database.Migrate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
        }
        private SimulatorViewModel createFlightViewModel()
        {
            return new SimulatorViewModel( new NavigationService(_navigationStore, createSimulatorViewModel, createVisualizer), _random);
        }
        private CreateFlightViewModel createSimulatorViewModel()
        {
            return new CreateFlightViewModel(_creator, new NavigationService (_navigationStore, createFlightViewModel, createVisualizer));
        }
        private VisualizerViewModel createVisualizer()
        {
            return new VisualizerViewModel(new NavigationService(_navigationStore, createFlightViewModel, createVisualizer));
        }
       
        
    }
}
