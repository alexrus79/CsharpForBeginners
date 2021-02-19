using System;
using System.Collections.Generic;

namespace HomeWork
{
    class ShowCase
    {
        private static int _quantity;
        private static List<ShowCase> _allShowCaseList = new List<ShowCase>();
        private int _id;
        private int _capacity;
        private List<Product> _productsList = new List<Product>(); // Product list in this ShowCase
        
        public ShowCase()
        {
            _capacity = 100;
            _id = ++_quantity;
            _allShowCaseList.Add(this);
        }
        public int id
        {
            get => _id;
        }
        public void GetInfo()
        {
            Console.WriteLine("ShowCaseID: {0} Free Space: {1}", _id, _capacity);
            GetProductsFromThisShowCase();
        }
        public bool PlaceProductInThisShowCase(Product product)
        {
            if (product.ShowCase == null && _capacity >= product.size)
            {
                _productsList.Add(product);
                _capacity = _capacity - product.size;
                product.ShowCase = this;
                return true;
            }
            else
                return false;
        }

        public bool RemeveProductFromThisShowCase(Product product)
        {
            if (product.ShowCase == this)
            {
                product.ShowCase = null;
                _capacity = _capacity + product.size;
                return (_productsList.Remove(product));
            }
            else
                return false;
        }
        public static void GetInfoAllShowCases()
        {
            foreach (var showCase in _allShowCaseList)
            {
                Console.WriteLine("ShowCaseID: {0} Free Space: {1} All products {2}", showCase.id, showCase._capacity, showCase._productsList.Count);
            }
        }
        public void GetProductsFromThisShowCase()
        {
            foreach (var product in _productsList)
            {
                Console.WriteLine("Product: " + product.Name + " ID: " + product.ID + " Size: " + product.size);
            }
        }

    }

}
