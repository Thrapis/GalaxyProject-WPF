using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectGalaxy.Models.Generaton
{
    public class GenerationOptions
    {
        public Point Center { get; set; } 
        public double CenterDiameter { get; set; } 
        public double Border { get; set; } 
        public float AmountOfStars { get; set; } 
        public float ArmSeparationDistance { get; set; } 
        public float MaxArmOffset { get; set; } 
        public float RandomOffsetXY { get; set; } 
        public float RotationFactor { get; set; }

        public GenerationOptions() { }

        public GenerationOptions(Point center, double diameter, double border, float amountOfStars,
            float armSeparationDistance, float maxArmOffset, float randomOffsetXY, float rotationFactor)
        {
            Center = center;
            CenterDiameter = diameter;
            Border = border;
            AmountOfStars = amountOfStars;
            ArmSeparationDistance = armSeparationDistance;
            MaxArmOffset = maxArmOffset;
            RandomOffsetXY = randomOffsetXY;
            RotationFactor = rotationFactor;
        }
    }
}
