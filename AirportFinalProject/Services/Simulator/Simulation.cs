using Airport.Data;
using Airport.Models;
using AirportFinalProject.Models;
using AirportFinalProject.Services.Flight.Creator;
using AirportFinalProject.ViewModels;
using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Threading;

namespace AirportFinalProject.Simulator
{
    class Simulation : ISimulation
    {
        private ContextFactory _factory;
        private Random _rnd;
        private readonly SimulatorViewModel _flightDataViewModel;
        private readonly VisualizerViewModel _visualizerViewModel;
        public Simulation(ContextFactory factory, Random rnd, SimulatorViewModel flightDataViewModel, VisualizerViewModel visualizerViewModel)
        {
            _visualizerViewModel = visualizerViewModel;
            _flightDataViewModel = flightDataViewModel;
            _factory = factory;
            _rnd = rnd;
        }
        public void RandomFlightSimulation()
        {
            DispatcherTimer dt = new DispatcherTimer(DispatcherPriority.Normal);
            dt.Interval = new TimeSpan(0, 0, 10);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            using (ProjectContext _context = _factory.CreateDBContext())
            {
                var flight = new Flight()
                {
                    FlightId = GetFlightId(),
                    FlightDate = DateTime.Now,
                    CompanyId = GetCompanyId(_context),
                    IsDeparture = IsDeparture(),

                };
                flight.FlightNumber = GetFlyNumber(flight.FlightId, flight.CompanyId, _context);
                if (flight.IsDeparture)
                {
                    flight.StationId = 1;
                }
                else if (!flight.IsDeparture)
                {
                    flight.StationId = 9;
                }
                Progress(_context);
                _context.Flights.Add(flight);
                EditHistory(_context);
                _context.SaveChanges();
                _visualizerViewModel.InitializePlanes();
                _flightDataViewModel.UpdateFlights();
            }
        }
        private string GetCompanyId(ProjectContext context)
        {
            var index = _rnd.Next(context.Companies.ToArray().Length);
            var company = context.Companies.Select(p => p.CompanyId).ToArray()[index];
            return company;
        }

        private bool IsDeparture()
        {
            bool randomBool = _rnd.Next(0, 2) > 0;
            return randomBool;
        }
        private string GetFlyNumber(string flightId, string companyId, ProjectContext context)
        {
            var company = context.Companies.SingleOrDefault(c => c.CompanyId == companyId);
            var name = company.CompanyName.ToUpper().Substring(0, 3);
            var flight = flightId.Substring(0, 4);
            var flyNumber = $"{name}-{flight}";
            return flyNumber;
        }
        private string GetFlightId()
        {
            var flightId = Guid.NewGuid().ToString();
            return flightId;
        }
        private void EditHistory(ProjectContext context)
        {
            if(context.HistoricalFlights.Count() > 10)
            {
                var number = context.HistoricalFlights.Count() - 10;
                var listToRemove = context.HistoricalFlights.OrderBy(f => f.FlightDate).Take(number);
                context.HistoricalFlights.RemoveRange(listToRemove);
            }
        }
        private void Progress(ProjectContext context)
        {
            foreach (var flight in context.Flights) 
            {
                if (flight.IsDeparture)
                {
                    ++flight.StationId;
                    if (flight.StationId > 5)
                    {
                        var hFlight = new FlightHistory()
                        {
                            FlightId = flight.FlightId,
                            FlightDate = flight.FlightDate,
                            IsDeparture = true,
                            CompanyId = flight.CompanyId,
                            FlightNumber = flight.FlightNumber
                        };
                        context.HistoricalFlights.Add(hFlight);
                        context.Flights.Remove(flight);

                    }
                }
                else if (flight.FlightDate > DateTime.Now.AddSeconds(25))
                {
                    context.Flights.Remove(flight);
                }
                else if (!flight.IsDeparture)
                {

                    flight.StationId--;
                    if (flight.StationId < 5)
                    {
                        var hFlight = new FlightHistory()
                        {
                            FlightId = flight.FlightId,
                            FlightDate = flight.FlightDate,
                            IsDeparture = false,
                            CompanyId = flight.CompanyId,
                            FlightNumber = flight.FlightNumber
                        };
                        context.HistoricalFlights.Add(hFlight);
                        context.Flights.Remove(flight);
                    }
                }
            }
        }
    }
}
