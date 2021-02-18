using System;

namespace HomeWork
{
    class Program
    {
        static void Main()
        {
            ShowCase shopWindow1 = new ShowCase();
            ShowCase shopWindow2 = new ShowCase();
            Product product1 = new Product(50, "Milk");
            Product product2 = new Product(40, "Fish");

            shopWindow1.PlaceProduct(product1);
            shopWindow1.PlaceProduct(product2);
            shopWindow1.GetInfo();
            product1.GetInfo();
            product2.GetInfo();
            Console.WriteLine();
            shopWindow1.DelProduct(product1);
            shopWindow1.GetInfo();
            product1.GetInfo();
            product2.GetInfo();




        }
    }
}