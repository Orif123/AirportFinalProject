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
        private readonly Func<BaseViewModel> _createHistory;
        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel>createViewModel, Func<BaseViewModel> createVisualizer, Func<BaseViewModel>createHistory)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createVisualizer = createVisualizer;
            _createHistory = createHistory;
        }
        public void Navigate()
        {
            _navigationStore.BaseViewModel = _createViewModel();
        }
        public void SeeVisualizer()
        {
            _navigationStore.BaseViewModel = _createVisualizer();
        }
        public void SeeHistory()
        {
            _navigationStore.BaseViewModel = _createHistory();
        }
    }
}
