using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjectGalaxy.Models.Transformation
{
    public struct RotateAction
    {
        public Point Location;
        public double AngleDelta;
        public RotateAction(Point location, double angleDelta)
        {
            Location = location;
            AngleDelta = angleDelta;
        }

        public Transform GetTransform()
        {
            return new RotateTransform(AngleDelta, Location.X, Location.Y);
        }
    }
}
