using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.FlightCreator
{
        public interface IFlightCreator
        {
            void CreateFlight(CreateFlightViewModel createViewModel);
        }
    
}
