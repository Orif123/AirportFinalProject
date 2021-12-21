using Airport.Data;
using Airport.Models;
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
        public Canvas Canvas;
        private ObservableCollection<VisualPlane> planes;
        private ObservableCollection<VisualStation> stations;
        public ObservableCollection<VisualPlane> Planes => InitializePlanes();
        public ObservableCollection<VisualStation> Stations => InitializeStations();
        public ICommand Navigate { get; }
        public VisualizerViewModel(NavigationService navigationService)
        {
            planes = new ObservableCollection<VisualPlane>();
            Navigate = new NavigationCommand(navigationService);
            GetPlanes();
        }
        public ObservableCollection<VisualStation> InitializeStations()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var cnvStations = _context.Stations.ToList();
                for (int i = 0; i < cnvStations.Count(); i++)
                {
                    cnvStations[i].StationId = i+1;
                    stations = new ObservableCollection<VisualStation>()
                    {
                        new VisualStation(551, 267, 60, 60, cnvStations[0]),
                        new VisualStation(438, 173, 60, 60, cnvStations[1]),
                        new VisualStation(1000, 103, 60, 60, cnvStations[2]),
                        new VisualStation(455, 68, 60, 60, cnvStations[3]),
                        new VisualStation(455, 68, 60, 60, cnvStations[4]),
                        new VisualStation(208, 269, 60, 60, cnvStations[5]),
                        new VisualStation(166, 98, 60, 60, cnvStations[6]),
                        new VisualStation(317, 7, 60, 60, cnvStations[7]),
                        new VisualStation(667, 4, 60, 60, cnvStations[8]),
                    };
                }
                return stations;
            }
        }
        public void GetPlanes()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new System.TimeSpan(0, 0, 3);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, System.EventArgs e)
        {
            InitializePlanes();
        }

        public ObservableCollection<VisualPlane> InitializePlanes()
        {
            using (ProjectContext _context = App._factory.CreateDBContext())
            {
                var cnvFlights = _context.Flights.Include(p => p.Company);
                planes.Clear();
                foreach (var flight in cnvFlights)
                {
                    var stationPlaced = InitializeStations().SingleOrDefault(p => p.StationId == flight.StationId);
                    var cnvFlight = new VisualPlane(stationPlaced.X, stationPlaced.Y, 60, 60, flight);
                    planes.Add(cnvFlight);
                }
                return planes;
            }
        }
        
    }
}
