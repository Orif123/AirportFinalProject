using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.FlightService
{
   public interface ICreateFlightService
    {
        void CreateFlight(CreateFlightViewModel createViewModel);
    }
}
