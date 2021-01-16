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
            string symbolStr  = "!?<>= ";             
            
            boolFlag = firstNum > secondNum; //true
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[4] + symbolStr[5] + firstNum);
            Console.WriteLine(secondStr + symbolStr[5] + symbolStr[4] + symbolStr[5] + secondNum);
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[3] + symbolStr[5] + secondStr + 
                symbolStr[1] + symbolStr[5]+ boolFlag + symbolStr[0]);
            boolFlag = firstNum < secondNum; //false
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[2] + symbolStr[5] + secondStr + 
                symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);
            boolFlag = firstNum == secondNum;
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[4] + symbolStr[5] + secondStr +
                symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);
            boolFlag = firstNum != secondNum;
            Console.WriteLine(firstStr + symbolStr[5] + symbolStr[0] + symbolStr[4] + symbolStr[5] + 
                secondStr + symbolStr[1] + symbolStr[5] + boolFlag + symbolStr[0]);
        }
    }
}