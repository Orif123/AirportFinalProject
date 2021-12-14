using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AirportFinalProject.VisualizerObjects
{
    public class BaseVisualObject
    {
        private Image _objectImage;

        public Image ObjectImage
        {
            get { return _objectImage; }
            set { _objectImage = value; }
        }
        private double _x;

        public double X
        {
            get { return _x; }
            set { _x = value; Canvas.SetLeft(_objectImage, _x); }
        }
        private double _y;

        public double Y
        {
            get { return _y; }
            set { _y = value; Canvas.SetTop(_objectImage, _y); }
        }
        public double Height
        {
            get
            {
                return _objectImage.ActualHeight;
            }
            set
            {
                _objectImage.Height = value;
            }
        }
        public double Width
        {
            get
            {
                return _objectImage.ActualWidth;
            }
            set
            {
                _objectImage.Width = value;
            }
        }
        public BaseVisualObject(double x, double y, double height, double width, string imagePath)
        {
            _objectImage = new Image();
            X = x;
            Y = y;
            _objectImage.Height = height;
            _objectImage.Width = width;
            _objectImage.Source = new BitmapImage(new Uri(imagePath));
        }
    }
}
