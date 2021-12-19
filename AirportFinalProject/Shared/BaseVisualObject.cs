using AirportFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AirportFinalProject.VisualizerObjects
{
    public class BaseVisualObject: BaseViewModel
    {
      
        private double _x;

        public double X
        {
            get { return _x; }
            set { _x = value;  OnPropertyChanged(nameof(X)); }
        }
        private double _y;

        public double Y
        {
            get { return _y; }
            set { _y = value; OnPropertyChanged(nameof(Y)); }
        }
        private double _height;
        public double Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged(nameof(Height)); }
        }
        private double _width;

        public double Width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged(nameof(Width)); }
        }

        public BaseVisualObject(double x, double y, double height, double width)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }
    }
}
