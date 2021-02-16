using System;
using System.Collections.Generic;
using System.Text;

namespace Customlnterface
{
    class ThreeDCircle : Circle, IDraw3D
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }

        public void Draw3D()
        { Console.WriteLine("Drawing Circle in 3D!"); }
    }
}
