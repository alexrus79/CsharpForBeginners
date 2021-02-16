using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class ShowCase
    {
        private static int _quantity;
        public readonly int _id;
        private int _capacity;

        public ShowCase()
        {
            _quantity++;
            _capacity = 100;
            _id = _quantity;
        }

        public void Info()
        {
            Console.WriteLine(_id + " " + _capacity);
        } 

    }
}
