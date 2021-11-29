using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.ViewModels;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class CreateFlightViewModel : BaseViewModel
    {
        private readonly ProjectContext _context;
        public CreateFlightViewModel(ProjectContext context)
        {
            _context = context;
            Submit = new FlightCommand(_context, this);
        }
        public ICommand Submit { get;}
        private string _companyId;

        public string CompanyId
        {
            get { return _companyId; }
            set
            {
                _companyId = value;
                OnPropertyChanged(nameof(CompanyId));
            }

        }
        private bool _isDeparture;

        public bool IsDeparture
        {
            get { return _isDeparture; }
            set
            {
                _isDeparture = value;
                OnPropertyChanged(nameof(IsDeparture));
            }

        }
       

    }
}