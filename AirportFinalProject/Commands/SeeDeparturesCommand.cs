using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    internal class SeeDeparturesCommand : CommandBase
    {
        private readonly IFlightProvider _provider;
        private readonly FlightDataViewModel _flightDataViewModel;
        public SeeDeparturesCommand(IFlightProvider provider, FlightDataViewModel flightDataViewModel)
        {
            _flightDataViewModel = flightDataViewModel;
            _provider = provider;
        }
        public override void Execute(object parameter)
        {
            _provider.GetDepartures();
        }
    }
}