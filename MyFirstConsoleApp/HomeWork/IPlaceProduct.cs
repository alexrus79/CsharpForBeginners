using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    interface IPlaceProduct
    {
        bool PlaceProduct();
        bool PlaceProduct(ShowCase showCase);
        bool DelProduct();
        bool DelProduct(ShowCase showCase);
    }
}
