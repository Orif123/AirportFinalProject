using Airport.Data;
using Airport.Models;
using AirportFinalProject.Services.FlightService;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Threading;

namespace AirportFinalProject.Commands
{
    class GenerateRandomFlightCommand : CommandBase
    {
        
        private readonly IFlightCreator _creator;
        private readonly CreateFlightViewModel _createFlightViewModel;
        public GenerateRandomFlightCommand(IFlightCreator creator, CreateFlightViewModel createFlightViewModel)
        {
            _creator = creator;
            _createFlightViewModel = createFlightViewModel;
        }
        public override void Execute(object parameter)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 5);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            _creator.CreateFlight(_createFlightViewModel);
        }

    }
}

