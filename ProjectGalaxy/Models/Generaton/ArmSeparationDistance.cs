using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGalaxy.Models.Generaton
{
    public class ArmSeparationDistance
    {
        public static float TwoArms { get; private set; }
        public static float ThreeArms { get; private set; }
        public static float FourArms { get; private set; }
        public static float FiveArms { get; private set; }
        public static float SixArms { get; private set; }

        static ArmSeparationDistance()
        {
            TwoArms = 3.3f;
            ThreeArms = 2f;
            FourArms = 1.5f;
            FiveArms = 1.25f;
            SixArms = 1f;
        }
    }
}
