using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Stores
{
    public class NavigationStore
    {
        private BaseViewModel _baseViewModel;

        public BaseViewModel BaseViewModel
        {
            get => _baseViewModel;
            set 
            {
                _baseViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public event Action CurrentViewModelChanged;
    }
}
