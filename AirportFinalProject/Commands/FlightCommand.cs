using Airport.Data;
using Airport.Models;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Commands
{
    class FlightCommand : CommandBase
    {
        private readonly ProjectContext _context;
        private readonly CreateFlightViewModel _createViewModel;
        public FlightCommand(ProjectContext context, CreateFlightViewModel createFlightViewModel)
        {
            _context = context;
            _createViewModel = createFlightViewModel;
        }
        public override void Execute(object parameter)
        {
            var flight = new Flight()
            {
                FlightId = GetFlightId(),
                FlightDate = DateTime.Now,
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
        }
        protected string GetFlyNumber(string flightId, string companyId)
        {
            var company = _context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
            var name = company.CompanyName.Substring(0, 3);
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
