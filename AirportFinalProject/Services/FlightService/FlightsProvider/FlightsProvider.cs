using Airport.Data;
using Airport.Models;
using AirportFinalProject.Data;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Services.FlightService.FlightsProvider
{
    class FlightsProvider : IFlightProvider
    {
        private readonly ContextFactory _contextFactory;
        public FlightsProvider(ContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public ObservableCollection<FlightViewModel> GetArrivals(FlightDataViewModel model)
        {
            using (ProjectContext _context = _contextFactory.CreateDBContext())
            {
                RandomGenerator.UpdateFlights(_context, model.Arrivals);
                return model.Arrivals;
            }
        }

        public ObservableCollection<FlightViewModel> GetDepartures(FlightDataViewModel model)
        {
            using (ProjectContext _context = _contextFactory.CreateDBContext())
            {
                RandomGenerator.UpdateFlights(_context, model.Departures);
                return model.Departures;
            }
        }
        
    }
}
