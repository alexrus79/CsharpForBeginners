using System;

namespace BasicInheritance
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("***** Basic Inheritance *****\n");
            // Make a Car object and set max speed.
            Car myCar = new Car(80);
            // Set the current speed, and print it.
            myCar.Speed = 90;
            Console.WriteLine("My car is going {0} MPH", myCar.Speed);

            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine("My van is going {0} MPH {1}", myVan.Speed, myVan.maxSpeed);

        }
    }
}
