using Airport.Data;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Commands
{
    class LoadFlightsCommand : CommandBase
    {
        private readonly ProjectContext _context;
        private readonly FlightDataViewModel _flightDataViewModel;
        public LoadFlightsCommand(ProjectContext context, FlightDataViewModel flightDataViewModel)
        {
            _context = context;
            _flightDataViewModel = flightDataViewModel;
        }
        public override void Execute(object parameter)
        {
            var flights = _context.Flights.ToList();

        }
    }
}
