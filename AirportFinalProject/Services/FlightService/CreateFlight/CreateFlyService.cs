using Airport.Data;
using Airport.Models;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Services.FlightService
{
    internal class CreateFlyService : FlightBase, ICreateFlightService

    {
        private readonly ProjectContext _context;
        private readonly FlightDataViewModel _flightDataViewModel;
        public CreateFlyService(ProjectContext context, FlightDataViewModel flightDataViewModel): base(context, flightDataViewModel)
        {
            _context=context;
            _flightDataViewModel = flightDataViewModel;
        }
        public void CreateFlight(CreateFlightViewModel createViewModel)
        {
            var flight = new Flight()
            {
                FlightId = GetFlightId(),
                FlightDate = createViewModel.FlightDate,
                CompanyId = createViewModel.CompanyId,
                IsDeparture = createViewModel.IsDeparture,
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
            UpdateFlights();
        }
    }
}
