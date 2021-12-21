using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Navigation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace AirportFinalProject.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        private NavigationService _navigationService;
        private ObservableCollection<HistoryFlightViewModel> history;

        public HistoryViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            history = new ObservableCollection<HistoryFlightViewModel>();
            History = CollectionViewSource.GetDefaultView(UpdateHistory());
            History.SortDescriptions.Add(new SortDescription(nameof(FlightViewModel.FlightDate), ListSortDirection.Ascending));
            Navigate = new NavigationCommand(_navigationService);
            GetHistory();
        }
        public ICommand Navigate { get; }
        public ICollectionView History { get; }
        public void GetHistory()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 3);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            UpdateHistory();
        }

        public ObservableCollection<HistoryFlightViewModel> UpdateHistory()
        {
            using(ProjectContext _context = App._factory.CreateDBContext())
            {
                var historyList = _context.HistoricalFlights.Include(p => p.Company);
                history.Clear();
                foreach (var flight in historyList)
                {
                    var hFlight = new HistoryFlightViewModel(flight);
                    history.Add(hFlight);
                }
                return history;
            }
        }
    }
}
