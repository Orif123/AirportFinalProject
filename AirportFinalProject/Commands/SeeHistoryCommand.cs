using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Commands
{
    class SeeHistoryCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;
        public SeeHistoryCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            _navigationService.SeeHistory();
        }
    }
}
