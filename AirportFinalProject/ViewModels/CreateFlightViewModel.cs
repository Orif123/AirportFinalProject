using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.FlightCreator;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Stores;
using AirportFinalProject.ViewModels;
using System;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class CreateFlightViewModel : BaseViewModel
    {
        private readonly IFlightCreator _flightCreator;


        public CreateFlightViewModel(IFlightCreator flightCreator, NavigationService navigationService)
        {
            _flightCreator = flightCreator;
            Submit = new FlightCommand(_flightCreator, this, navigationService);
            FlightData = new NavigationCommand(navigationService);
        }
        public ICommand Submit { get; }
        public ICommand FlightData { get; }
        private string _companyId;
        public string CompanyId
        {
            get { return _companyId; }
            set
            {
                _companyId = value;
                OnPropertyChanged(nameof(CompanyId));
            }
        }
        private DateTime _flightDate;

        public DateTime FlightDate
        {
            get { return _flightDate; }
            set
            {
                _flightDate = (DateTime)value;
                OnPropertyChanged(nameof(FlightDate));
            }

        }
        private bool _isDeparture;

        public bool IsDeparture
        {
            get { return _isDeparture; }
            set
            {
                _isDeparture = value;
                OnPropertyChanged(nameof(IsDeparture));
            }

        }
    }
}