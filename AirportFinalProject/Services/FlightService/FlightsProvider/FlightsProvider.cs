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
        private readonly FlightDataViewModel _flightViewModel;
        public FlightsProvider(ContextFactory contextFactory, FlightDataViewModel flightViewModel)
        {
            _contextFactory = contextFactory;
            _flightViewModel = flightViewModel;
        }
        public ObservableCollection<FlightViewModel> GetArrivals()
        {
            //using (ProjectContext _context = _contextFactory.CreateDBContext())
            //{
            //    //var list = _context.Flights.Where(a => a.IsDeparture == false).Include(p => p.Company).Include(p => p.Station);
            //    //_flightViewModel.Arrivals.Clear();
            //    //foreach (var flight in list)
            //    //{
            //    //    var viewModel = new FlightViewModel(flight);
            //    //    _flightViewModel.Arrivals.Add(viewModel);
            //    //}

            //} 
            return _flightViewModel.Arrivals;
        }

        public ObservableCollection <FlightViewModel> GetDepartures()
        {
           return _flightViewModel.Departures;
        }
    }
}
