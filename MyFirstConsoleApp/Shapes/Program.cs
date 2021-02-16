using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeDCircle o = new ThreeDCircle();
            o.Draw();
            // This calls the Draw() method of the parent!
            ((Circle)o).Draw();
        }
    }
}
