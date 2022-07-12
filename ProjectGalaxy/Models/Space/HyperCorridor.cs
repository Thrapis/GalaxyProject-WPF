using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectGalaxy.Models.Space
{
    public class HyperCorridor
    {
        public Star FromStar { get; set; }
        public Star ToStar { get; set; }

        public Point From { get { return new Point(FromStar.Position.X, FromStar.Position.Y); } }
        public Point To { get { return new Point(ToStar.Position.X, ToStar.Position.Y); } }

        public HyperCorridor(Star fromStar, Star toStar)
        {
            FromStar = fromStar;
            ToStar = toStar;
        }
    }
}
