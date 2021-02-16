using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customlnterface
{
    class PointyTestClass : IPointy
    {
        byte IPointy.Points => throw new NotImplementedException();
    }
}
