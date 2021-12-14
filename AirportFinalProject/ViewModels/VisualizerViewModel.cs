using Airport.Data;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.VisualizerObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace AirportFinalProject.ViewModels
{
    public class VisualizerViewModel : BaseViewModel
    {
        public Canvas _canvas;
        private ObservableCollection<BaseVisualObject> plans;
        private ObservableCollection<BaseVisualObject> stations;
        public ICollectionView Plans { get; }
        public ICollectionView Stations { get; }
        public VisualizerViewModel(NavigationService navigationService)
        {
            _canvas = new Canvas();
            plans = new ObservableCollection<BaseVisualObject>();
            stations = new ObservableCollection<BaseVisualObject>();
        }
        public void InitializeStations()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var cnvStations = _context.Stations.ToList();
                foreach (var station in cnvStations)
                {
                    var canvasStation = new BaseVisualObject((station.StationId + 1) * 160, 70, 100, 100, station.PhotoPath);
                    stations.Add(canvasStation);
                    _canvas.Children.Add(canvasStation.ObjectImage);
                }
            }
        }
        public void InitializePlans()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var cnvFlights = _context.Flights.Include(p => p.Company).ToList();
                foreach (var flight in cnvFlights)
                {
                    if (flight.IsDeparture)
                    {
                        var cnvFlight = new BaseVisualObject(140, 80, 30, 30, flight.Company.CompanyLogo);
                        _canvas.Children.Add(cnvFlight.ObjectImage);
                        plans.Add(cnvFlight);
                    }
                    else
                    {
                        var cnvFlight = new BaseVisualObject(70, 80, 30, 30, flight.Company.CompanyLogo);
                        _canvas.Children.Add(cnvFlight.ObjectImage);
                        plans.Add(cnvFlight);
                    }
                }
            }
        }
    }
}
