using System;

namespace HomeWork
{
    class ShowCase
    {
        private static int _quantity;
        public readonly int _id;
        private int _capacity;
        Product[] products = new Product[100];

        public ShowCase()
        {
            _capacity = 100;
            _id = ++_quantity;
        }

        public void Info()
        {
            Console.WriteLine(_id + " " + _capacity);
        }
        
    }

}
