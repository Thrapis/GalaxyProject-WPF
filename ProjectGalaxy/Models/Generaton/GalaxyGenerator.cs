using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectGalaxy.Models.Generaton
{
    public class GalaxyGenerator
    {

        public static Point[] GenerateGalaxy(GenerationOptions options)
        {
            Random random = new Random();
            List<Point> result = new List<Point>();
            for (int i = 0; i < options.AmountOfStars; i++)
            {
                // Choose a distance from the center of the galaxy.
                float distance = (float)(random.NextDouble() * (0.12 - 0.99) + 0.99);
                //distance = (float)Math.Pow(distance, 2);
                //distance = (float)Math.Sqrt(distance);

                // Choose an angle between 0 and 2 * PI.
                float angle = (float)random.NextDouble() * 2 * (float)Math.PI;
                float armOffset = (float)random.NextDouble() * options.MaxArmOffset;

                armOffset = armOffset - options.MaxArmOffset / 2;
                armOffset = armOffset * (1 / distance);

                float squaredArmOffset = (float)Math.Pow(armOffset, 2);

                // Take the positive value for the offset.
                if (armOffset < 0)
                {
                    squaredArmOffset = Math.Abs(squaredArmOffset); // * -1;
                }

                armOffset = squaredArmOffset;

                float rotation = distance * options.RotationFactor;

                // Compute the angle of the arms.
                angle = (int)(
                    (random.NextDouble() * (0.71 - 0.99) + 0.99) * // Not necessary to be here.
                        angle / options.ArmSeparationDistance) *
                        options.ArmSeparationDistance + armOffset + rotation;

                // Convert polar coordinates to 2D cartesian coordinates.
                float starX = (float)Math.Cos(angle) * distance;
                float starY = (float)Math.Sin(angle) * distance;

                float randomOffsetX = (float)random.NextDouble() * options.RandomOffsetXY;
                float randomOffsetY = (float)random.NextDouble() * options.RandomOffsetXY;

                // Apply the random offset.
                starX += randomOffsetX;
                starY += randomOffsetY;

                // Assign the proper x and y coordinates.
                //result.Add(new Point(starX, starY));
                result.Add(new Point(starX * options.Border / 2 + options.Center.X - options.CenterDiameter/2,
                    starY * options .Border/ 2 + options.Center.Y - options.CenterDiameter / 2));
            }
            return result.ToArray();
        }
    }
}
