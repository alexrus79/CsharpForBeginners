using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] deck =
            {
                2, 3 , 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
                2, 3 , 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
                2, 3 , 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
                2, 3 , 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11
            };

            Random random = new Random();
            int[] newDeck = new int[deck.Length - 1]; //новая колода будет на одну карту меньше
            do
            {
                int shuffle = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                int card = deck[shuffle]; //смотрим какая карты выпала

                Console.WriteLine("Card: " + card + " # " + (shuffle+1));

            
            
                for (int i = 0; i < deck.Length; i++)
                {
                    Console.WriteLine((i+1) + " " + deck[i]);
                }
            
            
                for (int i = 0; i < shuffle; i++) // удаляем из колоды вытянутую карту
                {
                    newDeck[i] = deck[i];
                }
            
                for (int i = shuffle; i < deck.Length-1; i++)
                {
                    newDeck[i] = deck[i+1];
                }

                deck = newDeck; // колода стала на одну карту меньше
                for (int i = 0; i < deck.Length; i++)
                {
                    Console.WriteLine((i+1) + " " + deck[i] + " " + deck.Length);
                }
            } while (deck.Length > 1);


        }
    }
}
