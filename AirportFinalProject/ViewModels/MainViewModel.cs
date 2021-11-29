using Airport.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly ProjectContext _context;
        public  BaseViewModel CurrentViewModel { get; }
        public MainViewModel(ProjectContext context)
        {
            _context = context;
            CurrentViewModel = new CreateFlightViewModel(_context);
        }
    }
}
