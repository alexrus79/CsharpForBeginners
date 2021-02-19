using System;
using System.Collections.Generic;

namespace HomeWork
{
    class ShowCase
    {
        private static List<ShowCase> _allShowCaseList = new List<ShowCase>();
        private int _id;
        private int _capacity;
        private List<Product> _productsList = new List<Product>(); // Product list in this ShowCase
        
        public ShowCase()
        {
            _capacity = 100;            
            _allShowCaseList.Add(this);
            _id = _allShowCaseList.Count;
        }
        public static int Quantity { get => _allShowCaseList.Count; }
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
            Console.WriteLine("Всего найдено витрин:" + _allShowCaseList.Count);
            foreach (var showCase in _allShowCaseList)
            {               
                Console.WriteLine("ID витрины: {0}\tСвободное место: {1}\tВсего товаров {2}", showCase._id, showCase._capacity, showCase._productsList.Count);
            }
        }
        public void GetProductsFromThisShowCase()
        {
            Console.WriteLine("Размещено товаров на витрине:" + _productsList.Count);
            Console.WriteLine();
            foreach (var product in _productsList)
            {             
                Console.WriteLine("Product: " + product.Name + " ID: " + product.ID + " Size: " + product.Size);
            }
        }

        public static bool DeleteShowCaseFromBase(ShowCase showCase)
        {
            if (showCase._productsList.Count > 0)
            {
                return false;
            }
            else if(_allShowCaseList.Remove(showCase))
            {
                return true;
            }
            return false;
        }
        public static ShowCase GetShowCaseFromID(int id)
        {
            foreach (var showCase in _allShowCaseList)
            {
                if (showCase._id == id)
                {
                    return showCase;
                }
            }
            return null;
        }
    }

}
