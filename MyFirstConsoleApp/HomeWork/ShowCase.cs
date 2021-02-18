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
        public void Info()
        {
            Console.WriteLine("ShowCaseID: {0} capacity: {1}", _id, _capacity);
            foreach (var product in productsList)
            {
                Console.WriteLine("Product: " + product.Name + " ID: " + product.ID);
            }
        }
        public bool PlaceProduct(Product product)
        {
            if (product.ShowCase == null)
            {
                productsList.Add(product);
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
                return (productsList.Remove(product));
            }
            else
                return false;
        }


        //public bool PlaceProduct(Product product)
        //{
        //    products.Add(product);
        //    return true;           
        //}
        //public bool DelProduct(Product product)
        //{
        //    if (products.Remove(product))
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
           
        //}
    }

}
