using System;
using System.Collections.Generic;

namespace lessonThree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { -3, 1, 2, 3, -1, -4, -4, -5, -2 };

            int[] numArr =
            {
                0, 0, 2, 3, 4, 2
            };

            Console.WriteLine(MinSum(numArr));

        }

        private static int MinSum(int [] arr)
        {
            if (arr.Length == 0) return 0;
            if (arr.Length != ((arr.Length / 2)*2)) return 0;
            int sum = 0;
            int minIndex = 0;
            int maxIndex = 0;
            int arrLength = arr.Length / 2;
            for (int i = 0; i < arrLength; i++)
            {
                int[] temp = new int[arr.Length - 2];
                int min = 2147483647;
                int max = 0;
                for (int n = 0; n < arr.Length; n++)
                {
                    if (arr[n] > max)
                    {
                        max = arr[n];
                        maxIndex = n;
                    }

                    if (arr[n] < min) 
                    { 
                        min = arr[n];
                        minIndex = n;
                    }
                }
                int count = 0;
                if (arr.Length > 2)
                {
                    for (int m = 0; m < arr.Length; m++)
                    {
                        if (m == minIndex || m == maxIndex) continue;
                        temp[count] = arr[m];
                        count++;
                    }
                }
                arr = temp;
                sum = sum + (min * max);
            }
            
            return sum;
        }

        private static int SummArr(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum = sum + arr[i];
                }
            }

            return sum;
        }

        private static int Solve(List<int> arr)
        {
            
            int result = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int n = 0; n < arr.Count; n++)
                {
                    if (arr[n] == -arr[i])
                    {
                        arr[n] = 0;
                        arr[i] = 0;
                        break;
                    }

                }

            }

            for (int i = 0; i < arr.Count; i++)
            {
                for (int n = 0; n < arr.Count; n++)
                {
                    if (arr[n] == arr[i] && n != i)
                    {
                        arr[n] = 0;
                        break;
                    }

                }

            }

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] != 0)
                {
                    result = arr[i];
                }

            }

            return result;
        }

    }

}

