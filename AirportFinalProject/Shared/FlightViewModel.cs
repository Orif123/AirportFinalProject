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
        public DateTime FlightDate => _flight.FlightDate;
        public bool IsDeparture => _flight.IsDeparture;
        public string CompanyName => _flight.Company.CompanyName;
        public string StationName => _flight.Station.StationName ;
    }
}