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
        private readonly Func<BaseViewModel> _createVisualizer;
        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel>createViewModel, Func<BaseViewModel> createVisualizer)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createVisualizer = createVisualizer;
        }
        public void Navigate()
        {
            _navigationStore.BaseViewModel = _createViewModel();
        }
        public void SeeVisualizer()
        {
            _navigationStore.BaseViewModel = _createVisualizer();
        }
    }
}
