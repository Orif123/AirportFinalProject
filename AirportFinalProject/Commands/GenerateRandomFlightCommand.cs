using Airport.Data;
using Airport.Models;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Threading;

namespace AirportFinalProject.Commands
{
    class GenerateRandomFlightCommand : CommandBase
    {
        private CollectionViewSource _viewSource;
        private ProjectContext _context;
        private Random _rnd;
        private readonly FlightDataViewModel _flightDataViewModel;
        public GenerateRandomFlightCommand(ProjectContext context, Random rnd, FlightDataViewModel flightDataViewModel)
        {
            _flightDataViewModel = flightDataViewModel;
            _context = context;
            _rnd = rnd;
        }
        public override void Execute(object parameter)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 5);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
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
            Progress();
            _context.Flights.Add(flight);
            _context.SaveChanges();
            _viewSource = new CollectionViewSource();
            _viewSource.Source = _flightDataViewModel.Flights;
            _viewSource.View.Refresh();
        }

        private string GetCompanyId()
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
        private string GetFlyNumber(string flightId, string companyId)
        {
            var company = _context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
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
        private void Progress()
        {
            foreach (var flight in _context.Flights)
            {
                if (flight.IsDeparture)
                {
                    flight.StationId++;
                    if (flight.StationId >= 4)
                    {
                        _context.Flights.Remove(flight);
                        _context.SaveChanges();
                    }
                }
                else if(!flight.IsDeparture)
                {
                    flight.StationId--;
                    if (flight.StationId <= 4)
                    {
                        _context.Flights.Remove(flight);
                        _context.SaveChanges();
                    }
                }
               
            }
        }
    }
}
