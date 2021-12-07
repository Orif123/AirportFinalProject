using Airport.Models;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AirportFinalProject.Services.FlightService.FlightsProvider
{
    public interface IFlightProvider
    {
       ObservableCollection<FlightViewModel> GetArrivals();
        ObservableCollection<FlightViewModel> GetDepartures();
    }
}
