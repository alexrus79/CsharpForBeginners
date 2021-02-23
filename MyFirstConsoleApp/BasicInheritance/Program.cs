using System;
using System.Data.SqlClient;

namespace BasicInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Interfaces *****\n");
            // All of these classes support the ICloneable interface.
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            ICloneable sqlCnn = new SqlConnection();
            // Therefore, they can all be passed into a method taking ICloneable.
            object newmyStr = myStr.Clone();
            object newunixOS = unixOS.Clone();
            object newsqlCnn = sqlCnn.Clone();
            Console.WriteLine("Your clone is a: {0}", newmyStr.GetType().Name);
            Console.WriteLine("Your clone is a: {0}", newunixOS.GetType().Name);
            Console.WriteLine("Your clone is a: {0}", newsqlCnn.GetType().Name);
            Console.ReadLine();
        }
        //private static void CloneMe(ICloneable c)
        //{
        //    // Clone whatever we get and print out the name.
        //    object theClone = c.Clone();
        //    Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
        //}
        //private static void CloneMe(object obj)
        //{
        //    // Clone whatever we get and print out the name.
        //    object newobj = obj; 
        //    Console.WriteLine("Your clone is a: {0}", newobj.GetType().Name);
        //}
    }
}
