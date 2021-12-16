﻿using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Simulator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace AirportFinalProject.ViewModels
{
    public class SimulatorViewModel : BaseViewModel
    {
        private readonly ISimulation _simulation;
        private readonly VisualizerViewModel _visualizerViewModel;
        public SimulatorViewModel(NavigationService navigationService, Random random)
        {
            _random = random;
            SeeVisualizer = new NavigateToVisualizerCommand(navigationService, _visualizerViewModel);
            _visualizerViewModel = new VisualizerViewModel(navigationService);
            _simulation = new Simulation(App._factory, _random, this, _visualizerViewModel);
            flightViewModels = new ObservableCollection<FlightViewModel>();
            Flights = CollectionViewSource.GetDefaultView(UpdateFlights());
            Flights.SortDescriptions.Add(new SortDescription(nameof(FlightViewModel.FlightDate), ListSortDirection.Ascending));
            Flights.Filter = FilterFlights;
            CreateFlight = new NavigationCommand(navigationService);
            CreateRandomFlights = new GenerateRandomFlightCommand(_simulation);
        }

        private Random _random;
        private ObservableCollection<FlightViewModel> flightViewModels;
        private string _flightFilter;

        public string FlightFilter
        {
            get { return _flightFilter; }
            set
            {
                _flightFilter = value;
                OnPropertyChanged(nameof(FlightFilter));
                Flights.Refresh();
            }
        }

        public ICollectionView Flights { get; }
        public ICommand CreateFlight { get; }
        public ICommand CreateRandomFlights { get; }
        public ICommand SeeVisualizer { get; }
       

        public ObservableCollection<FlightViewModel> UpdateFlights()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var list = _context.Flights.Include(p => p.Company).Include(p => p.Station);
                flightViewModels.Clear();
                foreach (var flight in list)
                {
                    var viewModel = new FlightViewModel(flight);
                    flightViewModels.Add(viewModel);
                }
                return flightViewModels;
            }
        }
        private bool FilterFlights(object obj)
        {
            if (obj is FlightViewModel flightViewModel)
            {
                return flightViewModel.IsDeparture == (FlightFilter == "Departures");
            }
            return false;
        }

    }
}