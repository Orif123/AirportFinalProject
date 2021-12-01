using Airport.Data;
using AirportFinalProject.Commands;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    internal class SeeDeparturesCommand : CommandBase
    {
        private readonly ProjectContext _projectContext;
        private readonly FlightDataViewModel _flightViewModels;
        public SeeDeparturesCommand(ProjectContext projectContext, FlightDataViewModel flightViewModel)
        {
            _projectContext = projectContext;
            _flightViewModels = flightViewModel;

        }
        public override void Execute(object parameter)
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