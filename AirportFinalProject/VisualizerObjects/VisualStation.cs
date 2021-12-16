using Airport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.VisualizerObjects
{
    public class VisualStation : BaseVisualObject
    {
        private readonly Station _station;

        public VisualStation(double x, double y, double height, double width, Station station) : base(x, y, height, width)
        {
            _station = station;
        }
        public int StationId => _station.StationId;
        public string ImagePath => _station.PhotoPath;
    }
}
