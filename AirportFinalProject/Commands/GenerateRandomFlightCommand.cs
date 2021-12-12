using Airport.Data;
using Airport.Models;
using AirportFinalProject.Simulator;
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
        ////private CollectionViewSource _viewSource;
        ////private ProjectContext _context;
        ////private Random _rnd;
        //private readonly FlightDataViewModel _flightDataViewModel;
        private readonly ISimulation _simulation;

        public GenerateRandomFlightCommand(ISimulation simulation)
        {
            _simulation = simulation;
        }
        public override void Execute(object parameter)
        {
            _simulation.RandomFlightSimulation();
        }

        //private void Dt_Tick(object sender, EventArgs e)
        //{
        //    var flight = new Flight()
        //    {
        //        FlightId = GetFlightId(),
        //        FlightDate = DateTime.Now,
        //        CompanyId = GetCompanyId(),
        //        IsDeparture = IsDeparture(),
                
        //    };
        //    flight.FlightNumber = GetFlyNumber(flight.FlightId, flight.CompanyId);
        //    if (flight.IsDeparture)
        //    {
        //        flight.StationId = 1;
        //    }
        //    else if (!flight.IsDeparture)
        //    {
        //        flight.StationId = 9;
        //    }
        //    _context.Flights.Add(flight);
        //    _context.SaveChanges();
        //    _flightDataViewModel.UpdateFlights();
        //    Progress();
        //}

        //private string GetCompanyId()
        //{
        //    var index = _rnd.Next(_context.Companies.ToArray().Length);
        //    var company = _context.Companies.Select(p => p.CompanyId).ToArray()[index];
        //    return company;
        //}

        //public bool IsDeparture()
        //{
        //    bool randomBool = _rnd.Next(0, 2) > 0;
        //    return randomBool;
        //}
        //private string GetFlyNumber(string flightId, string companyId)
        //{
        //    var company = _context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
        //    var name = company.CompanyName.ToUpper().Substring(0, 3);
        //    var flight = flightId.Substring(0, 4);
        //    var flyNumber = $"{name}-{flight}";
        //    return flyNumber;
        //}
        //private string GetFlightId()
        //{
        //    var flightId = Guid.NewGuid().ToString();
        //    return flightId;
        //}
        
        //private void Progress()
        //{
        //    foreach (var flight in _context.Flights)
        //    {
        //        if (flight.IsDeparture)
        //        {
        //            ++flight.StationId;
        //            if (flight.StationId > 5)
        //            {
        //                _context.Flights.Remove(flight);

        //            }
        //        }
        //        else if (!flight.IsDeparture)
        //        {
                 
        //            flight.StationId--;
        //            if (flight.StationId < 5)
        //            {
        //                _context.Flights.Remove(flight);
        //            }
        //        }


            }
        }
//    }
//}
