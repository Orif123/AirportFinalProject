using Airport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.VisualizerObjects
{
    public class VisualPlane : BaseVisualObject
    {
        private readonly Flight _flight;
        public VisualPlane(double x, double y, double height, double width, Flight flight) : base(x, y, height, width)
        {
            _flight = flight;
        }

        public bool IsDeparture => _flight.IsDeparture;
        public string ImagePath => _flight.Company.AirplanePath;

        public int StationId => (int)_flight.StationId;


    }
}
