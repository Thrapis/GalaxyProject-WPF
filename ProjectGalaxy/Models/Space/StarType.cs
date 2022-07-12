using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectGalaxy.Models.Space
{
    class StarType
    {
        private static Random _random;
        public static Brush TypeO { get; }
        public static Brush TypeB { get; }
        public static Brush TypeA { get; }
        public static Brush TypeF { get; }
        public static Brush TypeG { get; }
        public static Brush TypeK { get; }
        public static Brush TypeM { get; }
        public static Brush TypeBlackHole { get; }
        public static Brush RandomSimpleType
        {
            get
            {
                switch (_random.Next(0, 7))
                {
                    case 0: return TypeO;
                    case 1: return TypeB;
                    case 2: return TypeA;
                    case 3: return TypeF;
                    case 4: return TypeG;
                    case 5: return TypeK;
                    default: return TypeM;
                }
            }
        }
        static StarType()
        {
            _random = new Random();
            TypeO = Brushes.DeepSkyBlue;
            TypeB = Brushes.LightSkyBlue;
            TypeA = Brushes.White;
            TypeF = Brushes.LightYellow;
            TypeG = Brushes.Yellow;
            TypeK = Brushes.Orange;
            TypeM = Brushes.Red;
            var rgb = new RadialGradientBrush(Colors.Black, Colors.White);
            rgb.RadiusX = 2;
            rgb.RadiusY = 2;
            TypeBlackHole = rgb;
        }
    }
}
