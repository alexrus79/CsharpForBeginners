using System;

namespace Customlnterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IPointy[] myPointyObjects = {new Hexagon(), new Knife(), new Triangle(), new Fork(), new PitchFork()};
            foreach (IPointy i in myPointyObjects)
                Console.WriteLine("Object has {0} points.", i.Points);


        }
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                if (s is IPointy ip)
                    return ip;
            }
            return null;
        }
    }
        
}
