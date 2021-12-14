using Airport.Models;
using System;

namespace AirportFinalProject.ViewModels
{
    public class FlightViewModel : BaseViewModel
    {
        private readonly Flight _flight;
        public FlightViewModel(Flight flight)
        {
            _flight = flight;
        }
        public string FlightId => _flight.FlightId;
        public string FlightNumber => _flight.FlightNumber;
        public string FlightDate => _flight.FlightDate.ToString("HH:mm:ss");
        public bool IsDeparture => _flight.IsDeparture;
        public string CompanyName => _flight.Company.CompanyLogo;
        public string StationName => _flight.Station.StationName ;
    }
}