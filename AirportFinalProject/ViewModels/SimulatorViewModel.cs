using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.Services.FlightProvider;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Simulator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class SimulatorViewModel : BaseViewModel
    {
        private readonly ISimulation _simulation;
        private readonly IFlightProvider _provider;
        public SimulatorViewModel(NavigationService navigationService, Random random)
        {
            _random = random;
            _simulation = new Simulation(App._factory, _random, this);
            _provider = new FlightProvider(App._factory, this);
            flightViewModels = new ObservableCollection<FlightViewModel>();
            CreateFlight = new NavigationCommand(navigationService);
            CreateRandomFlights = new GenerateRandomFlightCommand(_simulation);
            SeeDepartures = new SeeDeparturesCommand(_provider);
            SeeArrivels = new SeeArrivelsCommand(_provider);
        }
        private Random _random;
        private ObservableCollection<FlightViewModel> flightViewModels;
        public ObservableCollection<FlightViewModel> Flights => flightViewModels;
        public ICommand CreateFlight { get; }
        public ICommand CreateRandomFlights { get; }
        public ICommand SeeDepartures { get; }
        public ICommand SeeArrivels { get; }


        public void UpdateFlights()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var list = _context.Flights.Where(a => a.IsDeparture).Include(p => p.Company).Include(p => p.Station);
                flightViewModels.Clear();
                foreach (var flight in list)
                {
                    var viewModel = new FlightViewModel(flight);
                    flightViewModels.Add(viewModel);
                }
            }
        }
    }
}
