using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.FlightService
{
    interface IFlightBase
    {
        string GetFlyNumber(string flightId, string companyId);
        string GetFlightId();
        void UpdateFlights();
    }
}
