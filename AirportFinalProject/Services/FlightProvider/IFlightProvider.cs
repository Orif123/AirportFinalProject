using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Services.FlightProvider
{
    public interface IFlightProvider
    {
        void LoadArrivels();
        void LoadDepartures();
    }
}
