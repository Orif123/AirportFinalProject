using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.Simulator;
using AirportFinalProject.VisualizerObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace AirportFinalProject.ViewModels
{
    public class VisualizerViewModel : BaseViewModel
    {
        private List<VisualPlane> planes;
        private ObservableCollection<VisualStation> stations;
        public ICollectionView Stations { get; }
        public ICommand Navigate { get; }
        public VisualizerViewModel(NavigationService navigationService)
        {
            planes = new List<VisualPlane>();
            stations = new ObservableCollection<VisualStation>();
            Stations = CollectionViewSource.GetDefaultView(InitializeStations());
            Planes = CollectionViewSource.GetDefaultView(InitializePlanes());
            Navigate = new NavigationCommand(navigationService);
            GetPlanes();
        }
        public ICollectionView Planes { get; }
        public ObservableCollection<VisualStation> InitializeStations()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var cnvStations = _context.Stations.ToList();
                foreach (var station in cnvStations)
                {
                    var canvasStation = new VisualStation(station.StationId * 100, 100, 80, 80, station);
                    stations.Add(canvasStation);
                }
                return stations;
            }
        }
        public void GetPlanes()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval= new System.TimeSpan(0, 0, 10);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, System.EventArgs e)
        {
            InitializePlanes();
        }

        public List<VisualPlane> InitializePlanes()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var cnvFlights = _context.Flights.Include(p => p.Company);
                planes.Clear();
                foreach (var flight in cnvFlights)
                {
                    var stationPlaced = stations.SingleOrDefault(p => p.StationId == flight.StationId);
                    var cnvFlight = new VisualPlane(stationPlaced.X, stationPlaced.Y, 30, 30, flight);
                    planes.Add(cnvFlight);
                    OnPropertyChanged(nameof(Planes));
                    
                }

                return planes;
            }
        }
        
    }
}
