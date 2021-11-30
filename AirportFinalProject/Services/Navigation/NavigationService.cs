using AirportFinalProject.Stores;
using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.Navigation
{
   public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _createViewModel;
        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel>createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.BaseViewModel = _createViewModel();
        }
    }
}
