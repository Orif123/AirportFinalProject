using Airport.Models;
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
                new Company { CompanyId = "Ori", CompanyName = "Iberia", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif", AirplanePath= "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Company { CompanyId = "ELA", CompanyName = "ElAl", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/EL AL.jpg", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Company { CompanyId = "luf", CompanyName = "Lufthansa", CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png", AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" }
                );
            modelBuilder.Entity<Station>().HasData(
                new Station { StationId = 1, StationName = "Garage", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Station { StationId = 2, StationName = "Last Preperation", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Station { StationId = 3, StationName = "Terminal", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Station { StationId = 4, StationName = "Taking off", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png" },
                new Station { StationId = 5, StationName = "Done", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif" },
                new Station { StationId = 6, StationName = "Landing", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif" },
                new Station { StationId = 7, StationName = "About to land", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif" },
                new Station { StationId = 8, StationName = "preparing to land", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif" },
                new Station { StationId = 9, StationName = "On Air", PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif" }
                );
        }

    }
}
