using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjectGalaxy.Models.Space
{
    public class Star
    {
        public Brush Color { get; set; }
        public double Diameter { get; set; }
        public Point Position { get; set; }
        public Point RealPosition { get { return new Point(Position.X - Diameter / 2, Position.Y - Diameter / 2); } }

        public Star(Brush color, double diameter, double x, double y)
        {
            Color = color;
            Diameter = diameter;
            Position = new Point(x, y);
        }

        public Star(Brush color, double diameter, Point point)
        {
            Color = color;
            Diameter = diameter;
            Position = point;
        }
        public double GetDistanceTo(Star star)
        {
            return Math.Sqrt(
                Math.Pow(this.Position.X - star.Position.X, 2) +
                Math.Pow(this.Position.Y - star.Position.Y, 2)
                );
        }
    }
}
