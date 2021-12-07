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
        public SeeDeparturesCommand(IFlightProvider provider)
        {
            _provider = provider;
        }
        public override void Execute(object parameter)
        {
            _provider.GetDepartures();
        }
    }
}