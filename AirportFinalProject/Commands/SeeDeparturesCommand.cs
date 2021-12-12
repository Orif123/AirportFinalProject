using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Flight.Creator;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    internal class SeeDeparturesCommand : CommandBase
    {
        private readonly ContextFactory _factory;
        private readonly FlightDataViewModel _flightViewModels;
        public SeeDeparturesCommand(ContextFactory factory, FlightDataViewModel flightViewModel)
        {
            _factory = factory;
            _flightViewModels = flightViewModel;
        }
        public override void Execute(object parameter)
        {
            using (ProjectContext _projectContext = _factory.CreateDBContext())
            {
                var list = _projectContext.Flights.Where(a => a.IsDeparture).Include(p => p.Company).Include(p => p.Station);
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