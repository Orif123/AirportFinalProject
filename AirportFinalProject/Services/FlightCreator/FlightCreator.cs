using Airport.Data;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

                Random _rnd = new Random();
                var flight = new Airport.Models.Flight()
                {
                    FlightId = Guid.NewGuid().ToString(),
                    CompanyId = createViewModel.CompanyId,
                    IsDeparture = createViewModel.IsDeparture,
                    FlightDate = createViewModel.FlightDate
                };
                flight.FlightNumber = GetFlyNumber(_context, flight.FlightId, flight.CompanyId);
                if (flight.IsDeparture)
                {
                    flight.StationId = 1;

                }
                else if (!flight.IsDeparture)
                {
                    flight.StationId = 9;
                }

                _context.Flights.Add(flight);
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
