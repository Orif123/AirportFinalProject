using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class SeeArrivelsCommand : CommandBase
    {
        private readonly IFlightProvider _provider;
        private readonly FlightDataViewModel _flightDataViewModel;
        public SeeArrivelsCommand(IFlightProvider provider, FlightDataViewModel flightDataViewModel)
        {
            _flightDataViewModel = flightDataViewModel;
            _provider = provider;
        }
        public override void Execute(object parameter)
        {
            _provider.GetArrivals(_flightDataViewModel);
        }
    }
}