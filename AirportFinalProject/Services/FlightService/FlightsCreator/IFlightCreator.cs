using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.FlightService
{
   public interface IFlightCreator
    {
        void CreateFlight(CreateFlightViewModel createViewModel);
    }
}
