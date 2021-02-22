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
        public int Id
        {
            get => _id;
        }
        public int ProductCount { get => _productsList.Count; }
        public int Capacity { get => _capacity; }
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
        public void GetProductsFromThisShowCase()
        {
            Console.WriteLine("Размещено товаров на витрине:" + _productsList.Count);
            Console.WriteLine();
            int pad = 0;
            foreach (var product in _productsList)
            {
                string productName = "";
                if (product.Name == null)
                {
                    productName = productName.PadRight(10);
                }
                else
                {
                    pad = 20 - product.Name.Length;
                    productName = product.Name.PadRight(pad);
                }
                Console.WriteLine("ID: " + product.ID + " \tТовар: " + productName  + " \tРазмер: " + product.Size + " \tСтоимость: " + product.Cost);
            }
        }
        public static int GetLastId()
        {
            int id = 0;
            foreach (var showCase in _allShowCaseList)
            {                
                if (showCase._id > id)
                {
                    id = showCase._id;
                }
            }
            return id;
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
        public static void GetGlobalInfo()
        {
            Console.WriteLine("Всего витрин: {0}", Quantity);
            Console.WriteLine("Всего товаров: {0} [Из них на складе: {1}] [На витринах: {2}]",
                Product.Quantity, Product.AllProductInWarehouse, Product.AllProductInShowCases);
            Console.WriteLine();
        }
        public static void GetInfoAllShowCases()
        {
            Console.WriteLine("Всего найдено витрин:" + _allShowCaseList.Count);
            foreach (var showCase in _allShowCaseList)
            {
                Console.WriteLine("ID витрины: {0}\tСвободное место: {1}\tВсего товаров {2}", showCase._id, showCase._capacity, showCase._productsList.Count);
            }
        }
        public static bool DeleteShowCaseFromBase(ShowCase showCase)
        {
            if (showCase._productsList.Count > 0)
            {
                return false;
            }
            else if (_allShowCaseList.Remove(showCase))
            {
                return true;
            }
            return false;
        }
    }

}