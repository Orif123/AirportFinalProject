using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class FlightDataViewModel : BaseViewModel
    {
        private  ProjectContext _projectContext;
        private  ObservableCollection<FlightViewModel> flightViewModels;
        public ObservableCollection<FlightViewModel> Flights => flightViewModels;
        public ICommand CreateFlight { get;}

        public FlightDataViewModel(NavigationService navigationService, ProjectContext projectContext)
        {
            _projectContext = projectContext;
            flightViewModels = new ObservableCollection<FlightViewModel>();
            CreateFlight = new NavigationCommand(navigationService);
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
