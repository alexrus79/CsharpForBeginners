using System;
using System.Collections.Generic;

namespace HomeWork
{
    class Product
    {
        #region Fields
        private static int _quantity;
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
            _size = 1;
            _name = "NoName";
            _allProduct.Add(this);
        }
        public Product(int sizeProduct, string nameProduct)
        {
            _id = ++_quantity;
            Size = sizeProduct;
            _name = nameProduct;
            _allProduct.Add(this);
        }
        #endregion

        public static int Quantity { get => _quantity; }
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
                return (showCase.PlaceProductInShowCase(this));
            }
            else
                return false;
        }

        public bool RemoveProduct(ShowCase showCase)
        {
            if (_ShowCase == showCase)
            {
                return (showCase.RemoveProductFromShowCase(this));
            }
            else
                return false;
        }
        public bool DelProductFromBase()
        {
            if (_ShowCase != null)
            {
                if (RemoveProduct(_ShowCase))
                {
                    _id = 0;
                    --_quantity;
                    return true;
                }
                else
                    return false;
            } 
            else
            {
                if (RemoveProduct(_ShowCase))
                {
                    _id = 0;
                    --_quantity;
                    return true;
                }
                else
                    return false;
            }
        }
        #endregion
    }
}