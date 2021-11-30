using Airport.Data;
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
        private readonly Random _random;
        private readonly NavigationStore _navigationStore;
        private  ProjectContext _context;
        public App()
        {
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
            return new FlightDataViewModel( new NavigationService( _navigationStore, createFlightDataViewModel), _context, _random);
        }
        private CreateFlightViewModel createFlightDataViewModel()
        {
            return new CreateFlightViewModel(_context, new NavigationService (_navigationStore, createFlightViewModel));
        }
    }
}
