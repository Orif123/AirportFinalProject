using Airport.Data;
using Airport.Models;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Services.FlightService.CreateRandomFlight
{
    class CreateRandomFlight : FlightBase, ICreateRandomFlight
    {
        private readonly ProjectContext _context;
        private readonly FlightDataViewModel _flightDataViewModel;
        private readonly Random _rnd;
        public CreateRandomFlight(ProjectContext context, FlightDataViewModel flightDataViewModel, Random rnd) : base(context, flightDataViewModel)
        {
            _flightDataViewModel = flightDataViewModel;
            _context = context;
            _rnd = rnd;
        }
        public void CreateRandomFlights()
        {
            var flight = new Flight()
            {
                FlightId = GetFlightId(),
                FlightDate = DateTime.Now,
                CompanyId = GetCompanyId(),
                IsDeparture = IsDeparture()
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
            Progress();
            _context.SaveChanges();
            UpdateFlights();
        }
        public string GetCompanyId()
        {
            var index = _rnd.Next(_context.Companies.ToArray().Length);
            var company = _context.Companies.Select(p => p.CompanyId).ToArray()[index];
            return company;
        }

        public bool IsDeparture()
        {
            bool randomBool = _rnd.Next(0, 2) > 0;
            return randomBool;
        }
        public void Progress()
        {
            foreach (var flight in _context.Flights)
            {
                if (flight.IsDeparture)
                {
                    flight.StationId++;
                    if (flight.StationId >= 4)
                    {
                        _context.Flights.Remove(flight);

                    }
                }
                else if (!flight.IsDeparture)
                {
                    flight.StationId--;
                    if (flight.StationId <= 4)
                    {
                        _context.Flights.Remove(flight);
                    }
                }

            }
        }
    }
}
