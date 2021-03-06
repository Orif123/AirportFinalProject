using Airport.Data;
using AirportFinalProject.Commands;
using AirportFinalProject.Services.Navigation;
using AirportFinalProject.VisualizerObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
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
                        new VisualStation(1000, 100, 60, 60, cnvStations[0]),
                        new VisualStation(1000, 200, 60, 60, cnvStations[1]),
                        new VisualStation(1000, 300, 60, 60, cnvStations[2]),
                        new VisualStation(1000, 400, 60, 60, cnvStations[3]),
                        new VisualStation(208, 100, 60, 60, cnvStations[4]),
                        new VisualStation(208, 200, 60, 60, cnvStations[5]),
                        new VisualStation(208, 300, 60, 60, cnvStations[6]),
                        new VisualStation(208, 400, 60, 60, cnvStations[7])
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
