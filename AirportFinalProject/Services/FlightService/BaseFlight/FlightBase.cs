using Airport.Data;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Services.FlightService
{
    class FlightBase: IFlightBase
    {
        private readonly ProjectContext _context;
        private readonly FlightDataViewModel _flightDataViewModel;
        public FlightBase(ProjectContext context, FlightDataViewModel flightDataViewModel)
        {
            _context = context;
            _flightDataViewModel = flightDataViewModel;
        }
        public string GetFlyNumber(string flightId, string companyId)
        {
            var company = _context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
            var name = company.CompanyName.ToUpper().Substring(0, 3);
            var flight = flightId.Substring(0, 4);
            var flyNumber = $"{name}-{flight}";
            return flyNumber;
        }
        public string GetFlightId()
        {
            var flightId = Guid.NewGuid().ToString();
            return flightId;
        }
        public void UpdateFlights()
        {
            var list = _context.Flights.Where(a => a.IsDeparture).Include(p => p.Company).Include(p => p.Station);
            _flightDataViewModel.Flights.Clear();
            foreach (var flight in list)
            {
                var viewModel = new FlightViewModel(flight);
                _flightDataViewModel.Flights.Add(viewModel);
            }
        }
    }
}
