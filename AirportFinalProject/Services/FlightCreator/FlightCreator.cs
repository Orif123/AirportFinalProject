using Airport.Data;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace AirportFinalProject.Services.FlightCreator
{
    class FlightCreator : IFlightCreator
    {
        private readonly ContextFactory _contextFactory;
        public FlightCreator(ContextFactory contextFactory)
        {

            _contextFactory = contextFactory;
        }


        public void CreateFlight(CreateFlightViewModel createViewModel)
        {
            using (ProjectContext _context = _contextFactory.CreateDBContext())
            {
                var flight = new Airport.Models.Flight()
                {
                    FlightId = Guid.NewGuid().ToString(),
                    CompanyId = createViewModel.CompanyId,
                    IsDeparture = createViewModel.IsDeparture,
                    FlightDate = DateTime.Now
                };
                flight.FlightNumber = GetFlyNumber(_context, flight.FlightId, flight.CompanyId);
                foreach (var Flight in _context.Flights)
                {
                    if (Flight.StationId == 8 || Flight.StationId == 1)
                    {
                        MessageBox.Show("Cant Add");
                        _context.Flights.Remove(flight);
                    }
                    if (flight.IsDeparture && Flight.StationId != 1 && Flight.StationId !=8)
                    {
                        flight.StationId = 1;
                        _context.Flights.Add(flight);
                    }
                    else if (!flight.IsDeparture && Flight.StationId != 8 && Flight.StationId != 1)
                    {
                        flight.StationId = 8;
                        _context.Flights.Add(flight);
                    }
                }
                _context.SaveChanges();

            }
        }
        private string GetFlyNumber(ProjectContext context, string flightId, string companyId)
        {

            var company = context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
            var name = company.CompanyName.ToUpper().Substring(0, 3);
            var flight = flightId.Substring(0, 4);
            var flyNumber = $"{name}-{flight}";
            return flyNumber;
        }

    }
}
