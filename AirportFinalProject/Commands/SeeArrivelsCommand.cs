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
        public SeeArrivelsCommand(IFlightProvider provider)
        {
            _provider = provider;
        }
        public override void Execute(object parameter)
        {
            _provider.GetArrivals();
        }
    }
}