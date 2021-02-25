using System;

namespace Clientbase
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            Console.WriteLine(matrix[1, 1]);
            matrix[0, 0] = 111;
            Console.WriteLine(matrix[0, 0]);
        }
    }

}

