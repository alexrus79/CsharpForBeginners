using System;

namespace HomeWork
{
    class Program
    {
        static void Main()
        {
            ShowCase shopWindow = new ShowCase();
            ShowCase shopWindow1 = new ShowCase();
            ShowCase shopWindow2 = new ShowCase();
            shopWindow.Info();
            shopWindow1.Info();
            shopWindow2.Info();

            Product product1 = new Product(200, "Milk");
            product1.GetInfo();
            Product product2 = new Product(55, "Chocolate");
            product2.GetInfo();
            Console.WriteLine(product2.size = 60);

            Product product3 = new Product();
            product3.GetInfo();
            Product product4 = new Product();
            product4.GetInfo();




        }
    }
}