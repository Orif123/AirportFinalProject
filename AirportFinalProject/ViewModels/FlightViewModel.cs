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
        public string CompanyName => _flight.Company.CompanyName;
        public string StationName => _flight.Station.StationName ;
    }
}