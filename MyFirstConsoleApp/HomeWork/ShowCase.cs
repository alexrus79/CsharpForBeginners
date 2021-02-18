using System;
using System.Collections.Generic;

namespace HomeWork
{
    class ShowCase
    {
        private static int _quantity;
        private int _id;
        private int _capacity;
        private List<Product> productsList = new List<Product>();
        public ShowCase()
        {
            _capacity = 100;
            _id = ++_quantity;
        }
        public int id 
        {
            get => _id;
        }
        public void GetInfo()
        {
            Console.WriteLine("ShowCaseID: {0} Free Space: {1}", _id, _capacity);
            foreach (var product in productsList)
            {
                Console.WriteLine("Product: " + product.Name + " ID: " + product.ID + " Size: " + product.size);
            }
        }
        public bool PlaceProduct(Product product)
        {
            if (product.ShowCase == null && _capacity >= product.size)
            {
                productsList.Add(product);
                _capacity = _capacity - product.size;
                product.ShowCase = this;
                return true;
            }
            else
                return false;
        }

        public bool DelProduct(Product product)
        {
            if (product.ShowCase == this)
            {
                product.ShowCase = null;
                _capacity = _capacity + product.size;
                return (productsList.Remove(product));
            }
            else
                return false;
        }

    }

}
