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
        private string _name;
        private ShowCase _showCase = null;
        #endregion
        #region Ctor
        public Product() 
        {            
            ++_countProductInWarehouse;
            _size = 1;
            _name = "NoName";
            _allProduct.Add(this);
            _id = _allProduct.Count;
        }
        public Product(int sizeProduct, string nameProduct)
        {
            ++_countProductInWarehouse;
            Size = sizeProduct;
            _name = nameProduct;
            _allProduct.Add(this);
            _id = _allProduct.Count;
        }
        #endregion
        public static int Quantity { get => _allProduct.Count; }
        public static int AllProductInShowCases { get => _countProductInShowCases; }
        public static int AllProductInWarehouse { get => _countProductInWarehouse; }
        public int Size
        {
            get => _size;
            set
            {
                if (value > 100)
                    _size = 100;
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
        public string Name { get => _name; }
        public int ID { get => _id; }
        #region Methods
        public void GetInfo()
        {
            Console.WriteLine("ID: {0}\tProduct: {1}\tsize: {2}\tShowCaseID: {3}", _id, _name, _size, ShowCase?.Id ?? 0);
        }
        public static void GetInfoAllProduct()
        {
            Console.WriteLine("Всего найдено товаров:" + Quantity);
            foreach (var product in _allProduct)
            {
                product.GetInfo();
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
        public static void ShowProductsInWarehouse()
        {
            Console.WriteLine("Товаров на складе: {0}", _countProductInWarehouse);

            foreach (var product in _allProduct)
            {
                if (product._showCase == null)
                {
                    product.GetInfo();
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