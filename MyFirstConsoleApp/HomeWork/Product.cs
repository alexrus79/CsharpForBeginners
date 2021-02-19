﻿using System;

namespace HomeWork
{
    class Product
    {
        private static int _quantity;
        private int _id;
        private int _size;
        private string _name;
        private ShowCase _ShowCase = null;
        

        public Product() 
        {
            _id = ++_quantity;
            _size = 1;
            _name = "NoName";            
        }
        public Product(int sizeProduct, string nameProduct)
        {
            _id = ++_quantity;
            size = sizeProduct;
            _name = nameProduct;
        }

        
        public int size
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
        public void GetInfo()
        {
            Console.WriteLine("ID: {0} Product: {1} size: {2} ShowCaseID: {3}", _id, _name, _size, this.ShowCase?.id ?? 0);
        }

        public bool PlaceProduct(ShowCase showCase)
        {
            if (_ShowCase == null)
            {
                return (showCase.PlaceProductInThisShowCase(this));
            }
            else
                return false;
        }

        public bool DelProduct(ShowCase showCase)
        {
            if (_ShowCase == showCase)
            {
                return (showCase.RemeveProductFromThisShowCase(this));
            }
            else
                return false;
        }

    }
}