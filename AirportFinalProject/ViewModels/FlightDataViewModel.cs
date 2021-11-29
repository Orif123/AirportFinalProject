using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AirportFinalProject.ViewModels
{
    public class FlightDataViewModel : BaseViewModel
    {
        private readonly ObservableCollection<FlightViewModel> flightViewModels;
        public ObservableCollection<FlightViewModel> Flights => flightViewModels;

        public FlightDataViewModel()
        {
            flightViewModels = new ObservableCollection<FlightViewModel>();
            
        }

       

    }
}
