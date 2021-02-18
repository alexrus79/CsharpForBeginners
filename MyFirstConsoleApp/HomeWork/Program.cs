using System;

namespace HomeWork
{
    class Program
    {
        static void Main()
        {
            ShowCase shopWindow = new ShowCase();
            Product product1 = new Product(200, "Milk");
            Product product2 = new Product(50, "Fish");
            
            product1.PlaceProduct(shopWindow);
            product2.PlaceProduct(shopWindow);
            shopWindow.Info();
            product1.GetInfo();
            product2.GetInfo();

            Console.WriteLine();

            product1.DelProduct(shopWindow);
            shopWindow.Info();
            product1.GetInfo();
            product2.GetInfo();


            //shopWindow.Info();
            //product1.GetInfo();
            //Console.WriteLine();




        }
    }
}