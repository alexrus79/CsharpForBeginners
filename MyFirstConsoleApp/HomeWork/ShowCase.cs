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
        public bool PlaceProductInShowCase(Product product)
        {
            if (product.ShowCase == null && _capacity >= product.Size)
            {
                _productsList.Add(product);
                _capacity = _capacity - product.Size;
                product.ShowCase = this;
                return true;
            }
            else
                return false;
        }

        public bool RemoveProductFromShowCase(Product product)
        {
            if (product.ShowCase == this)
            {
                product.ShowCase = null;
                _capacity = _capacity + product.Size;
                return (_productsList.Remove(product));
            }
            else
                return false;
        }
        public static void GetInfoAllShowCases()
        {
            Console.WriteLine("Всего найдено витрин:" + _quantity);
            foreach (var showCase in _allShowCaseList)
            {               
                Console.WriteLine("ShowCaseID: {0} Free Space: {1} All products {2}", showCase._id, showCase._capacity, showCase._productsList.Count);
            }
        }
        public void GetProductsFromThisShowCase()
        {
            Console.WriteLine("Всего найдено товаров:" + Product.Quantity);
            foreach (var product in _productsList)
            {             
                Console.WriteLine("Product: " + product.Name + " ID: " + product.ID + " Size: " + product.Size);
            }
        }

    }

}
