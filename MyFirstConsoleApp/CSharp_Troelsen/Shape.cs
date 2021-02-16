using System;
using System.Collections.Generic;
using System.Text;

namespace Customlnterface
{
    abstract class Shape
    {
        public Shape(string name = "NoName")
        { PetName = name; }
        public string PetName { get; set; }
        // A single virtual method.
        public abstract void Draw();        
    }
}
