using Airport.Models;
using AirportFinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Airport.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {

        }
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<FlightHistory> HistoricalFlights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-EKQUKID;Database=AirportData;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
        .HasOne(a => a.Station)
        .WithOne(b => b.Flight)
        .HasForeignKey<Station>(b => b.FlightId);
            modelBuilder.Entity<Station>()
        .HasOne(a => a.Flight)
        .WithOne(b => b.Station)
        .HasForeignKey<Flight>(b => b.StationId);
            modelBuilder.Entity<Company>()
                .HasMany(p => p.Flights)
                .WithOne(c => c.Company);
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = "ELA", CompanyName = "ElAl", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/EL AL.jpg", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Company { CompanyId = "Ind", CompanyName = "Air India", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Air India.png", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-transparent-boeing-737-next-generation-boeing-787-dreamliner-boeing-777-boeing-c-32-boeing-767-air-india-mode-of-transport-flight-airplane.png" },
                new Company { CompanyId = "Bri", CompanyName = "British Airways", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/British-Airways-Logo-1997-present.jpg", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-clipart-boeing-737-next-generation-boeing-767-airplane-boeing-777-boeing-787-dreamliner-france-flights-flight-fundal.png" },
                new Company { CompanyId = "Wiz", CompanyName = "Wizzair", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/WizzAir.png", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-transparent-airplane-flight-david-the-builder-kutaisi-international-airport-wizz-air-air-travel-airport-transfer-transport-vehicle-volaris-thumbnail.png" },
                new Company { CompanyId = "Fly", CompanyName = "Emirates", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Emirates.png", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-clipart-boeing-737-next-generation-boeing-777-airbus-a380-airbus-a330-boeing-767-emirates-airline-mode-of-transport-airplane.png" },
                new Company { CompanyId = "Uni", CompanyName = "United", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/UnitedLogo.png", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/united-airlines-png-download-wide-body-aircraft-11562996046xxkz9rk4h2.png" },
                new Company { CompanyId = "luf", CompanyName = "Lufthansa", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-clipart-boeing-737-next-generation-boeing-767-airplane-boeing-777-boeing-787-dreamliner-france-flights-flight-fundal.png" }
                );
            modelBuilder.Entity<Station>().HasData(
                new Station { StationId = 1, StationName = "Garage", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/1-Number-PNG.png" },
                new Station { StationId = 2, StationName = "Last Preperation", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/2-Number-PNG.png" },
                new Station { StationId = 3, StationName = "Terminal", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/3-Number-PNG.png" },
                new Station { StationId = 4, StationName = "Taking off", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/4-Number-PNG.png" },
                new Station { StationId = 5, StationName = "Done", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/5-Number-PNG.png" },
                new Station { StationId = 6, StationName = "Landing", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/6-Number-PNG.png" },
                new Station { StationId = 7, StationName = "About to land", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/7-Number-PNG.png" },
                new Station { StationId = 8, StationName = "preparing to land", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/8-Number-PNG.png" }
                );
        }

    }
}
