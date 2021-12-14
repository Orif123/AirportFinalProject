using AirportFinalProject.Services.Navigation;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Commands
{
    public class NavigateToVisualizerCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;
        private readonly VisualizerViewModel _visualizerViewModel;
        public NavigateToVisualizerCommand(NavigationService navigationService, VisualizerViewModel visualizerViewModel)
        {
            _navigationService = navigationService;
            _visualizerViewModel = visualizerViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationService.SeeVisualizer();
            _visualizerViewModel.InitializeStations();
            _visualizerViewModel.InitializePlans();
        }
    }
}
