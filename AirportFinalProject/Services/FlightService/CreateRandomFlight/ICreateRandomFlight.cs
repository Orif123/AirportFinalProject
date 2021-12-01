using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.FlightService.CreateRandomFlight
{
    public interface ICreateRandomFlight
    {
        void CreateRandomFlights();
        string GetCompanyId();
        bool IsDeparture();
        void Progress();
    }
}
