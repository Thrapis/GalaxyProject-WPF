using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjectGalaxy.Models.Transformation
{
    public struct ZoomAction : ITransformAction
    {
        public Point Location;
        public double Zoom;
        public ZoomAction(Point location, double zoom)
        {
            Location = location;
            Zoom = zoom;
        }

        public Transform GetTransform()
        {
            return new ScaleTransform(Zoom, Zoom, Location.X, Location.Y);
        }
    }
}
