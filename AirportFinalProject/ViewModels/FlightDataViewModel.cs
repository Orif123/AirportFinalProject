using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class FlightDataViewModel : BaseViewModel
    {
        
        private  ProjectContext _projectContext;
        private Random _random;
        private  ObservableCollection<FlightViewModel> flightViewModels;
        public ObservableCollection<FlightViewModel> Flights => flightViewModels;
        public ICommand CreateFlight { get;}
        public ICommand CreateRandomFlights { get;}

        public FlightDataViewModel(NavigationService navigationService, ProjectContext projectContext, Random random)
        {
            _projectContext = projectContext;
            _random = random;
            flightViewModels = new ObservableCollection<FlightViewModel>();
            CreateFlight = new NavigationCommand(navigationService);
            CreateRandomFlights = new GenerateRandomFlightCommand(projectContext, _random, this);
            UpdateFlights();
          
        }

        private void UpdateFlights()
        {
            flightViewModels.Clear();
            foreach (var flight in _projectContext.Flights)
            {
               
                var viewModel = new FlightViewModel(flight);
                flightViewModels.Add(viewModel);
            }
        }
        
           
        
    }
}
