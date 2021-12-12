using Airport.Data;
using Airport.Models;
using AirportFinalProject.Simulator;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Threading;

namespace AirportFinalProject.Commands
{
    class GenerateRandomFlightCommand : BaseCommand
    {
        private readonly ISimulation _simulation;

        public GenerateRandomFlightCommand(ISimulation simulation)
        {
            _simulation = simulation;
        }
        public override void Execute(object parameter)
        {
            _simulation.RandomFlightSimulation();
        }
    }
}

