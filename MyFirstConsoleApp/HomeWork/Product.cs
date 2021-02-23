using System;
using System.Collections.Generic;

namespace HomeWork
{
    class Product
    {
        #region Fields
        private static int _countProductInShowCases;
        private static int _countProductInWarehouse;
        private static List<Product> _allProduct = new List<Product>();
        private int _id;
        private int _size;
        private double _cost;
        private string _name;
        private ShowCase _showCase = null;
        #endregion
        #region Ctor
        public Product() 
        {
            _cost = 0;
            ++_countProductInWarehouse;
            _size = 1;
            Name = "NoName";
            _allProduct.Add(this);
            _id = _allProduct.Count;
        }
        public Product(int sizeProduct, string nameProduct, double costProduct)
        {
            ++_countProductInWarehouse;
            Size = sizeProduct;
            Name = nameProduct;
            _allProduct.Add(this);
            _id = _allProduct.Count;
            Cost = costProduct;
        }
        #endregion
        public static int Quantity { get => _allProduct.Count; }
        public static int AllProductInShowCases { get => _countProductInShowCases; }
        public static int AllProductInWarehouse { get => _countProductInWarehouse; }
        public double Cost 
        {
            get => _cost; 
            set
            {
                _cost = value;
            }
        }
        public int Size
        {
            get => _size;
            set
            {
                if (value > 100)
                    _size = 100;
                else
                    _size = value;
                if (value <= 0)
                    _size = 1;
                else
                    _size = value;
            }
        }
        public ShowCase ShowCase
        {
            get => _showCase;
            set
            {
                _showCase = value;
            }
        }
        public string Name 
        { 
            get => _name;
            set
            {
                if (value.Length > 15)
                {
                    int temp = value.Length - 15;
                    _name = value.Substring(0, value.Length - temp);
                }
                else
                    _name = value;
            }
        }
        public int ID { get => _id; }
        #region Methods
        public static void GetInfo(Product product)
        {
            int pad = 0;
            string productName = "";
            if (product._name == null)
            {
                productName = productName.PadRight(10);
            }
            else
            {
                pad = 15 - product._name.Length;
                productName = product._name.PadRight(pad);
            }
            Console.WriteLine("ID: {0}\tТовар: {1} \tразмер: {2}\tID витрины: {3}", product._id, productName, product._size, product.ShowCase?.Id ?? 0);
        }
        public static void GetInfoAllProduct()
        {
            Console.WriteLine("Всего найдено товаров:" + _allProduct.Count);
            Console.WriteLine();
            foreach (var product in _allProduct)
            {
                GetInfo(product);
            }
        }
        public bool PlaceProduct(ShowCase showCase)
        {
            if (_showCase == null)
            {
                --_countProductInWarehouse;
                ++_countProductInShowCases;
                return (showCase.PlaceProductInShowCase(this));
            }
            else
                return false;
        }
        public bool RemoveProduct(ShowCase showCase)
        {
            if (_showCase == showCase)
            {
                ++_countProductInWarehouse;
                --_countProductInShowCases;
                return (showCase.RemoveProductFromShowCase(this));
            }
            else
                return false;
        }
        public static Product GetProductFromID(int id)
        {
            foreach (var product in _allProduct)
            {
                if (product._id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public static void GetProductsInWarehouse()
        {
            Console.WriteLine("Всего товаров на складе: {0}", _countProductInWarehouse);
            Console.WriteLine();
            foreach (var product in _allProduct)
            {
                if (product._showCase == null)
                {
                    GetInfo(product);
                }
            }
        }
        public static void GetProductsInShowCase()
        {
            Console.WriteLine("Всего товаров на витринах: {0}", _countProductInShowCases);
            Console.WriteLine();
            foreach (var product in _allProduct)
            {
                if (product._showCase != null)
                {
                    GetInfo(product);
                }
            }
        }
        public static bool DelProductFromBase(Product product)
        {
            if (product._showCase != null && product.RemoveProduct(product._showCase))
            {
                _allProduct.Remove(product);
                --_countProductInWarehouse;

                return true;
            } 
            else if (product._showCase == null)
            {
                _allProduct.Remove(product);
                --_countProductInWarehouse;
                return true;
            }
            return false;
        }
        #endregion
    }
}