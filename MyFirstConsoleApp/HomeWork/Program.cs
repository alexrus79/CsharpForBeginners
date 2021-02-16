using System;

namespace FirstProg
{
    class Program
    {
        static void Main()
        {
            bool[] mass = new bool[1_000_000_000];
            for (uint i = 1; i < mass.Length; i = i + 2)
            {
                mass[i] = true;
                //uint c = 0;
                //if (i > 1)
                //{
                //    for (uint s = i * i; s <= mass.Length - 1; s = (i * i) + c * i)
                //    {
                //        mass[s] = false;
                //        c++;
                //    }
                //}
            }

            Console.WriteLine("Start...");

            mass[0] = false;
            mass[1] = false;
            mass[2] = true;

            DateTime start = DateTime.Now;

            double sqrtMassLength = Math.Sqrt(mass.Length);
            int massLength = mass.Length - 1;

            for (uint i = 3; i <= sqrtMassLength; i = i + 2)
            {
                if (mass[i])
                {
                    uint n = 0;
                    uint numberQuad = i * i;
                    for (uint j = numberQuad; j <= massLength; j = numberQuad + n * i)
                    {
                        mass[j] = false;
                        n++;
                    }
                }
               

            }

            TimeSpan result = DateTime.Now - start;
            Console.WriteLine(result.ToString());

            uint m=0;

            for (uint i = 0; i < mass.Length; i++)
            {
                if (mass[i] == true)
                {
                    //Console.WriteLine(i);
                    m++;                    
                }
            }

            Console.WriteLine();
            Console.WriteLine(m);



        }

    }

}