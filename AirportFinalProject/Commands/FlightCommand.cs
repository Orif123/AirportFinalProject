using Airport.Data;
using Airport.Models;
using AirportFinalProject.Services.FlightCreator;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Commands
{
    class FlightCommand : BaseCommand
    {
        private readonly IFlightCreator _flightCreator;
        private readonly CreateFlightViewModel _createViewModel;
        private readonly NavigationService _navigationService;
        public FlightCommand(IFlightCreator flightCreator, CreateFlightViewModel createFlightViewModel, NavigationService navigationService)
        {
            _flightCreator = flightCreator;
            _createViewModel = createFlightViewModel;
            _navigationService = navigationService;
            _createViewModel.PropertyChanged += ViewModelPropertyChanged;
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateFlightViewModel.CompanyId))
            {
                OnCanExecuteChange();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(_createViewModel.CompanyId)  && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {

            _flightCreator.CreateFlight(_createViewModel);
            _navigationService.Navigate();
        }
    }
}
