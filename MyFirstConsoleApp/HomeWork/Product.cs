using System;
using System.Collections.Generic;

namespace HomeWork
{
    class Product
    {
        #region Fields
        private static int _quantity;
        private static int _countProductInShowCases;
        private static int _countProductInWarehouse;
        private static List<Product> _allProduct = new List<Product>();
        private int _id;
        private int _size;
        private string _name;
        private ShowCase _ShowCase = null;
        #endregion

        #region Ctor
        public Product() 
        {
            _id = ++_quantity;
            ++_countProductInWarehouse;
            _size = 1;
            _name = "NoName";
            _allProduct.Add(this);
        }
        public Product(int sizeProduct, string nameProduct)
        {
            _id = ++_quantity;
            ++_countProductInWarehouse;
            Size = sizeProduct;
            _name = nameProduct;
            _allProduct.Add(this);
        }
        #endregion

        public static int Quantity { get => _quantity; }
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
            get {return _ShowCase; }
            set { _ShowCase = value; }
        }
        public string Name { get => _name; }
        public int ID { get => _id; }

        #region Methods
        public void GetInfo()
        {
            Console.WriteLine("ID: {0} Product: {1} size: {2} ShowCaseID: {3}", _id, _name, _size, this.ShowCase?.id ?? 0);
        }
        public static void GetInfoAllProduct()
        {
            Console.WriteLine("Всего найдено товаров:" + Product.Quantity);
            foreach (var product in _allProduct)
            {
                Console.WriteLine("ID: {0} Product: {1} size: {2} ShowCaseID: {3}", product.ID, product.Name, product.Size, product.ShowCase?.id ?? 0);
            }
        }

        public bool PlaceProduct(ShowCase showCase)
        {
            if (_ShowCase == null)
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
            if (_ShowCase == showCase)
            {
                ++_countProductInWarehouse;
                --_countProductInShowCases;
                return (showCase.RemoveProductFromShowCase(this));
            }
            else
                return false;
        }
        public static bool DelProductFromBase(Product product)
        {
            if (product._ShowCase != null && product.RemoveProduct(product._ShowCase))
            {
                _allProduct.Remove(product);
                --_countProductInWarehouse;

                return true;
            } 
            else if (product._ShowCase == null)
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