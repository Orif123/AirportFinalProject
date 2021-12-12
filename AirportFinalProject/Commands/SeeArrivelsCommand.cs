using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.FlightService.FlightsProvider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace AirportFinalProject.ViewModels
{
    public class SeeArrivelsCommand : CommandBase
    {
        private readonly IFlightProvider _provider;
        private readonly FlightDataViewModel _flightDataViewModel;
        public SeeArrivelsCommand(IFlightProvider provider, FlightDataViewModel flightDataViewModel)
        {
            _flightDataViewModel = flightDataViewModel;
            _provider = provider;
        }
        public override void Execute(object parameter)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            _flightDataViewModel.Arrivels.CollectionChanged += Arrivals_CollectionChanged;
        }

        private void Arrivals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _provider.GetArrivals();
        }
    }
}