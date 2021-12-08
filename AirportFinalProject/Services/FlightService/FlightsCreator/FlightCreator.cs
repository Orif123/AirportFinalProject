using Airport.Data;
using Airport.Models;
using AirportFinalProject.Data;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Services.FlightService
{
    public class FlightCreator : IFlightCreator

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
                var flight = new Flight()
                {
                    FlightId = GetFlightId(),
                    CompanyId = createViewModel.CompanyId,
                    IsDeparture = createViewModel.IsDeparture,
                    FlightDate = createViewModel.FlightDate
                };
                if (createViewModel.CompanyId is null)
                {
                    Progress(_context);
                    flight.CompanyId = RandomGenerator.GetCompanyId(_context, _rnd);
                    flight.IsDeparture = RandomGenerator.IsDeparture(_rnd);
                    flight.FlightDate = DateTime.Now;
                }
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
        private string GetFlightId()
        {
            var flightId = Guid.NewGuid().ToString();
            return flightId;
        }

        private void Progress(ProjectContext context)
        {
            foreach (var flight in context.Flights)
            {
                if (flight.IsDeparture)
                {
                    ++flight.StationId;
                    if (flight.StationId > 5)
                    {
                        context.Flights.Remove(flight);
                    }
                }
                else if (!flight.IsDeparture)
                {

                    --flight.StationId;
                    if (flight.StationId < 5)
                    {
                        context.Flights.Remove(flight);
                    }
                }



            }
        }
    }
    public static class RandomGenerator
    {
        public static ObservableCollection<FlightViewModel> UpdateFlights(ProjectContext context, bool isDeparture)
        {
            var list = new ObservableCollection<FlightViewModel>();
            list.Clear();
            var dataList = context.Flights.Where(p=>p.IsDeparture == isDeparture).Include(p => p.Company).Include(p => p.Station).ToList();
            foreach (var flight in dataList)
            {
                var myList = new FlightViewModel(flight);
                list.Add(myList);
            }
            return list;

        }
        public static string GetCompanyId(ProjectContext context, Random rnd)
        {
            var index = rnd.Next(context.Companies.ToArray().Length);
            var company = context.Companies.Select(p => p.CompanyId).ToArray()[index];
            return company;
        }

        public static bool IsDeparture(Random rnd)
        {
            bool randomBool = rnd.Next(0, 2) > 0;
            return randomBool;
        }
    }
}
