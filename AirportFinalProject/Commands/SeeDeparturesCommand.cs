using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.Services.FlightProvider;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    internal class SeeDeparturesCommand : BaseCommand
    {
        
        private readonly IFlightProvider _provider;
        public SeeDeparturesCommand(IFlightProvider provider)
        {
            _provider = provider;
        }
        public override void Execute(object parameter)
        {
            _provider.LoadDepartures();
        }
    }
}