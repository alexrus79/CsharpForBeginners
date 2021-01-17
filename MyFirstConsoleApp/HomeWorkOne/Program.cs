using System;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolFlag;
            byte firstNum = 255;
            sbyte secondNum = 127;
            string firstStr = "firstNum";
            string secondStr = "secondNum";
            string symbolStr = "!?<>= ";

            boolFlag = firstNum > secondNum;
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[4] + symbolStr[5] + firstNum);
            Console.WriteLine(secondStr + symbolStr[5] + symbolStr[4] + symbolStr[5] + secondNum);
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[3] + symbolStr[5] + secondStr +
                symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);
            boolFlag = firstNum < secondNum;
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[2] + symbolStr[5] + secondStr +
                symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);
            boolFlag = firstNum == secondNum;
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[4] + symbolStr[5] + secondStr +
                symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);
            boolFlag = firstNum != secondNum;
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[0] + symbolStr[4] + symbolStr[5] +
                secondStr + symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);

            byte byteNumFull = 255;
            byte over = 1;
            int intNumber = byteNumFull;
            intNumber = intNumber + over;
            byteNumFull = (byte)intNumber;
            Console.WriteLine("0-255 -> " + byteNumFull + " Переполнение типа byte на " + over);

            uint uintNumFull = 4294967295;
            over = 10;
            ulong ulongNumber = uintNumFull;
            ulongNumber = ulongNumber + over;
            uintNumFull = (uint)ulongNumber;
            Console.WriteLine("0-4294967295 -> " + uintNumFull + " Переполнение типа uint на " + over);

            int intNumFull = 2147483647;
            over = 100;
            long longNumber = intNumFull;
            longNumber = longNumber + over;
            intNumFull = (int)longNumber;
            Console.WriteLine("-2147483648 - 2147483647 -> " + intNumFull + " Переполнение типа int на " + over);
        }
    }
}