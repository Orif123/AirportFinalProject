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

        public NavigateToVisualizerCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            _navigationService.SeeVisualizer();
        }
    }
}
