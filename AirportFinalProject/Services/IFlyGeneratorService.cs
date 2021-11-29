using Airport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Services
{
    interface IFlyGeneratorService
    {
        void GetRandomFlight();
        string GetFlightId();
        string GetCompanyName();
        string GetFlyNumber(string flightId, string companyName);
        bool IsDeparture();
    }
}
