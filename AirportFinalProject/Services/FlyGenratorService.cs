using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Airport.Services
{
    public class FlyGenratorService : IFlyGeneratorService
    {
        private readonly Random _rnd;
        private readonly ProjectContext _context;


        public FlyGenratorService(Random rnd, ProjectContext context)
        {
            _rnd = rnd;
            _context = context;
        }



        public string GetCompanyName()
        {
            var companies = _context.Companies.ToArray();
            var index = _rnd.Next(companies.Length);
            var company = companies[index];
            return company.CompanyId;
        }

        public string GetFlightId()
        {
            var flightId = Guid.NewGuid().ToString();
            return flightId;
        }

        public string GetFlyNumber(string flightId, string companyName)
        {
            var company = _context.Companies.SingleOrDefault(c => c.CompanyId == companyName);
            var name = company.CompanyName.Substring(0, 3);
            var flight = flightId.Substring(0, 4);
            var flyNumber = $"{name}-{flight}";
            return flyNumber;
        }

        public void GetRandomFlight()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 3);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            Flight flight = new Flight();
            flight.FlightId = GetFlightId();
            flight.CompanyId = GetCompanyName();
            flight.FlightNumber = GetFlyNumber(flight.FlightId, flight.CompanyId);
            flight.IsDeparture = IsDeparture();
            flight.FlightDate = DateTime.Now;
            if (flight.IsDeparture)
            {
                flight.StationId = 1;
            }
            flight.StationId = 7;
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public bool IsDeparture()
        {
            bool randomBool = _rnd.Next(0, 2) > 0;
            return randomBool;
        }
    }
}
