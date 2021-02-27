using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class Demo
    {
        private List<Product> products = new List<Product>()
        {
           new Product(1, "Молоко" ,2.0),
           new Product(2, "Сахао" ,2.3),
           new Product(3, "Конфеты" ,3.2),
           new Product(4, "Шоколад" ,1.5),
           new Product(5, "Пиво" ,4),
           new Product(6, "Коньяк" ,5.3),
           new Product(7, "Консервы" ,2.0),
           new Product(8, "Макароны" ,2.0),
           new Product(9, "Печенье" ,2.0),
           new Product(10, "Сигареты" ,2.0),
           new Product(20, "Водка" ,2.0),
        };

        private List<ShowCase> showCases = new List<ShowCase>()
        {
            new ShowCase(),
            new ShowCase()
        };        
    }
}
