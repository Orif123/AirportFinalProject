using Airport.Data;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportFinalProject.Services.FlightProvider
{
    class FlightProvider : IFlightProvider
    {
        private ContextFactory _factory;
        private SimulatorViewModel _flightViewModels;
        public FlightProvider(ContextFactory factory, SimulatorViewModel flightViewModel)
        {
            _factory = factory;
            _flightViewModels = flightViewModel;
        }

        public void LoadArrivels()
        {
            using (ProjectContext _projectContext = _factory.CreateDBContext())
            {
                var list = _projectContext.Flights.Where(a => a.IsDeparture == false).Include(p => p.Company).Include(p => p.Station);
                _flightViewModels.Flights.Clear();
                foreach (var flight in list)
                {
                    var viewModel = new FlightViewModel(flight);
                    _flightViewModels.Flights.Add(viewModel);
                }
            }
        }

        public void LoadDepartures()
        {
            using (ProjectContext _projectContext = _factory.CreateDBContext())
            {
                var list = _projectContext.Flights.Where(a => a.IsDeparture == false).Include(p => p.Company).Include(p => p.Station);
                _flightViewModels.Flights.Clear();
                foreach (var flight in list)
                {
                    var viewModel = new FlightViewModel(flight);
                    _flightViewModels.Flights.Add(viewModel);
                }
            }
        }
    }
}
