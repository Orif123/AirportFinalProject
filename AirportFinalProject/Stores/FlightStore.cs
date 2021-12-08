using Airport.Data;
using Airport.Models;
using AirportFinalProject.Data;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Stores
{
    public class FlightStore
    {
        private readonly ContextFactory _context;
        private readonly List<Flight> _flights;
        public IEnumerable<Flight> Flights => _flights;
        public FlightStore()
        {
            _flights = new List<Flight>();
        }
        public void LoadArrivels()
        {

        }
    }
}
