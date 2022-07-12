using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjectGalaxy.Models.Transformation
{
    public struct MoveAction
    {
        public Vector Offset;
        public MoveAction(double xOffset, double yOffset)
        {
            Offset = new Vector(xOffset, yOffset);
        }

        public Transform GetTransform()
        {
            return new TranslateTransform(Offset.X, Offset.Y);
        }
    }
}
