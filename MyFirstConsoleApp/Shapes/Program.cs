using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = 10;
            things[3] = "Last thing";
            foreach (object item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null)
                    Console.WriteLine("Item is not a hexagon");
                else
                {
                    h.Draw();
                }
            }
        }
    }
}
