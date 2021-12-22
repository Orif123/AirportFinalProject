using AirportFinalProject.Models;
using System;

namespace AirportFinalProject.ViewModels
{
    internal class HistoryFlightViewModel : BaseViewModel
    {
        private readonly FlightHistory _flight;
        public HistoryFlightViewModel(FlightHistory flight)
        {
            _flight = flight;
        }
        public string FlightId => _flight.FlightId;
        public string FlightNumber => _flight.FlightNumber;
        public DateTime FlightDate => _flight.FlightDate;
        public string WrittenFlightDate => _flight.FlightDate.ToString("HH:MM:ss");
        public bool IsDeparture => _flight.IsDeparture;
        public string CompanyName => _flight.Company.CompanyLogo;
    }
}