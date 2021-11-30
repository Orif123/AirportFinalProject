using Airport.Data;
using AirportFinalProject.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly ProjectContext _context;
        private readonly NavigationStore _navigation;
        public BaseViewModel CurrentViewModel => _navigation.BaseViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigation = navigationStore;
            _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
