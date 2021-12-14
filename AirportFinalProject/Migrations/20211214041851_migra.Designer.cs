﻿// <auto-generated />
using System;
using Airport.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportFinalProject.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20211214041851_migra")]
    partial class migra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airport.Models.Company", b =>
                {
                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirplanePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = "Ori",
                            AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            CompanyName = "Iberia"
                        },
                        new
                        {
                            CompanyId = "ELA",
                            AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/EL AL.jpg",
                            CompanyName = "ElAl"
                        },
                        new
                        {
                            CompanyId = "luf",
                            AirplanePath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            CompanyLogo = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png",
                            CompanyName = "Lufthansa"
                        });
                });

            modelBuilder.Entity("Airport.Models.Flight", b =>
                {
                    b.Property<string>("FlightId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeparture")
                        .HasColumnType("bit");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StationId")
                        .IsUnique()
                        .HasFilter("[StationId] IS NOT NULL");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Airport.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlightId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StationId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            StationId = 1,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "Garage"
                        },
                        new
                        {
                            StationId = 2,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "Last Preperation"
                        },
                        new
                        {
                            StationId = 3,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "Terminal"
                        },
                        new
                        {
                            StationId = 4,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "Taking off"
                        },
                        new
                        {
                            StationId = 5,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "Done"
                        },
                        new
                        {
                            StationId = 6,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "Landing"
                        },
                        new
                        {
                            StationId = 7,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "About to land"
                        },
                        new
                        {
                            StationId = 8,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "preparing to land"
                        },
                        new
                        {
                            StationId = 9,
                            PhotoPath = "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif",
                            StationName = "On Air"
                        });
                });

            modelBuilder.Entity("Airport.Models.Flight", b =>
                {
                    b.HasOne("Airport.Models.Company", "Company")
                        .WithMany("Flights")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Airport.Models.Station", "Station")
                        .WithOne("Flight")
                        .HasForeignKey("Airport.Models.Flight", "StationId");

                    b.Navigation("Company");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Airport.Models.Company", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Airport.Models.Station", b =>
                {
                    b.Navigation("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
