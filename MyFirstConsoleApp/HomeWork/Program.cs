using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowCase showCase1 = new ShowCase();
            ShowCase showCase2 = new ShowCase();
            ShowCase showCase3 = new ShowCase();
            ShowCase showCase4 = new ShowCase();
            Product product1 = new Product(10, "kasjdhfladfhalsdfhlasdfhas", 12.2);
            Product product2 = new Product(11, "15102983520523045897230587203458720345782034578", 12.5);
            Product product3 = new Product();
            Product product4 = new Product();
            Product product5 = new Product();
            Product product6 = new Product();
            Product product7 = new Product();
            Product product8 = new Product();
            Product product9 = new Product();
            Product product10 = new Product();

            product1.PlaceProduct(showCase1);
            product2.PlaceProduct(showCase1);
            product3.PlaceProduct(showCase1);

            Menu.Start();
        }
    }
}