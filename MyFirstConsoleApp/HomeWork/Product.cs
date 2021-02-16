using System;

namespace HomeWork
{
    class Product
    {
        private static int _quantity;
        private int _id;
        private int _size;
        private string _name;
        private int _idShowCase;
        

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

        public int idShowCase { get; set; }
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
        public void AddToShowCase()
        {

        }
        public void DelFromShowCase()
        {
            
        }

        public void GetInfo()
        {
            Console.WriteLine("ID: {0} Product: {1} size: {2}", _id, _name, _size);
        }
      
    }
}
