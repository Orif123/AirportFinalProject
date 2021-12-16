using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Simulator;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Commands
{
    public class NavigateToVisualizerCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;
        private readonly ISimulation _simulation;

        public NavigateToVisualizerCommand(NavigationService navigationService, ISimulation simulation)
        {
            _navigationService = navigationService;
            _simulation = simulation;
        }
        public override void Execute(object parameter)
        {
            _navigationService.SeeVisualizer();
            _simulation.RandomFlightSimulation();
        }
    }
}
