﻿using Airport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                new Company { CompanyId = "Ori", CompanyName = "Iberia", CompanyLogo = "Logo" },
                new Company { CompanyId = "ELA", CompanyName = "ElAl", CompanyLogo = "Logo" },
                new Company { CompanyId = "LUF", CompanyName = "Lufthansa", CompanyLogo = "Logo" }
                );
            modelBuilder.Entity<Station>().HasData(
                new Station { StationId = 1, StationName = "Garage" },
                new Station { StationId = 2, StationName = "Last Preperation"},
                new Station { StationId = 3, StationName = "Terminal" },
                new Station { StationId = 4, StationName = "Taking off" },
                new Station { StationId = 5, StationName = "Done" },
                new Station { StationId = 6, StationName = "Landing" },
                new Station { StationId = 7, StationName = "About to land" },
                new Station { StationId = 8, StationName = "preparing to land" },
                new Station { StationId = 9, StationName = "On Air" }
                );
        }

    }
}
