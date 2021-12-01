using Airport.Data;
using Airport.Models;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Commands
{
    class FlightCommand : CommandBase
    {
        private readonly ProjectContext _context;
        private readonly CreateFlightViewModel _createViewModel;
        private readonly NavigationService _navigationService;
        public FlightCommand(ProjectContext context, CreateFlightViewModel createFlightViewModel, NavigationService navigationService)
        {
            _context = context;
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
            return !String.IsNullOrEmpty(_createViewModel.CompanyId) && DateTime.Now <= _createViewModel.FlightDate && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            var flight = new Flight()
            {
                FlightId = GetFlightId(),
                FlightDate = _createViewModel.FlightDate,
                CompanyId = _createViewModel.CompanyId,
                IsDeparture = _createViewModel.IsDeparture,
            };
            flight.FlightNumber = GetFlyNumber(flight.FlightId, flight.CompanyId);
            if (flight.IsDeparture)
            {
                flight.StationId = 1;
            }
            else if (!flight.IsDeparture)
            {
                flight.StationId = 7;
            }
            _context.Flights.Add(flight);
            _context.SaveChanges();
            _navigationService.Navigate();
        }
        protected string GetFlyNumber(string flightId, string companyId)
        {
            var company = _context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
            var name = company.CompanyName.ToUpper().Substring(0, 3);
            var flight = flightId.Substring(0, 4);
            var flyNumber = $"{name}-{flight}";
            return flyNumber;
        }
        private string GetFlightId()
        {
            var flightId = Guid.NewGuid().ToString();
            return flightId;
        }
    }
}
