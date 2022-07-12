using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectGalaxy.Models.Transformation
{
    public interface ITransformAction
    {
        public Transform GetTransform();
    }
}
