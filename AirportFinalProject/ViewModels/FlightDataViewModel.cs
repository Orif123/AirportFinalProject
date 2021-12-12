using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Data;
using AirportFinalProject.Services.FlightService;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using AirportFinalProject.Services.Navigation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class FlightDataViewModel : BaseViewModel
    {
        private readonly IFlightCreator _creator;
        private readonly IFlightProvider _provider;
        private readonly ProjectContext _context;
        private CreateFlightViewModel _createFlightViewModel;


        public ObservableCollection<FlightViewModel> Arrivels => UpdateFlights();
       

        public ObservableCollection<FlightViewModel> Departures => _provider.GetDepartures();
        public ICommand CreateFlight { get; }
        public ICommand CreateRandomFlights { get; }
        public ICommand SeeDepartures { get; }
        public ICommand SeeArrivels { get; }

        public FlightDataViewModel(NavigationService navigationService, IFlightCreator creator, IFlightProvider provider, ProjectContext context)
        {
            _context = context;
            _creator = creator;
            _provider = provider;
            
            CreateFlight = new NavigationCommand(navigationService);
            CreateRandomFlights = new GenerateRandomFlightCommand(_creator, _createFlightViewModel);
            SeeDepartures = new SeeDeparturesCommand(_provider, this);
            SeeArrivels = new SeeArrivelsCommand(_provider, this);

        }
        public ObservableCollection<FlightViewModel> UpdateFlights()
        {
            var arrivals = new ObservableCollection<FlightViewModel>();
            var list = _context.Flights.Where(a => a.IsDeparture).Include(p => p.Company).Include(p => p.Station);
            arrivals.Clear();
            foreach (var flight in list)
            {
                var viewModel = new FlightViewModel(flight);
                arrivals.Add(viewModel);
            }
            return arrivals;

        }


    }
}
