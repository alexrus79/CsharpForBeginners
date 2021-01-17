using System;

namespace RussianBlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            string questionPlay = "Дилер: Сыграем? (y/n)";
            string questionPlayAgain = "Дилер: Сыграем еще раз? (y/n)";
            string questionMore = "Дилер: Еще? (y/n)";
            string phraseDealerPas = "Дилер: Я пас!";
            string phraseDealerHand = "У дилера на руках: ";
            string phraseYourHand = "У Вас в руке: ";
            string phraseYouLose = "Вы проиграли!";
            string phraseYouWin = "Вы выиграли!!!";
            bool againGameAttribute = false;

            do
            {
                int[] deck =
                {
                    2, 3, 4, 6, 7, 8, 9, 10, 11,
                    2, 3, 4, 6, 7, 8, 9, 10, 11,
                    2, 3, 4, 6, 7, 8, 9, 10, 11,
                    2, 3, 4, 6, 7, 8, 9, 10, 11
                };

                if (againGameAttribute == false)
                {
                    do
                    {                        
                        Console.Write(questionPlay);
                        answer = Console.ReadLine();
                    } while (answer != "y" && answer != "n") ;
                }

                if (answer == "y")
                {
                    Random random = new Random();
                    int[] dealerHand = new int[1];
                    int[] playerHand = new int[1];
                    int[] newDeck = new int[deck.Length - 1]; //создаем массив для временной колоды

                    //сдаем карту игроку

                    int shuffle = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                    playerHand[playerHand.Length - 1] = deck[shuffle]; //присваиваем карту игроку                                                          
                    for (int i = 0; i < shuffle; i++) //удаляем из колоды вытянутую карту
                    {
                        newDeck[i] = deck[i];
                    }
                    for (int i = shuffle; i < deck.Length - 1; i++)
                    {
                        newDeck[i] = deck[i + 1];
                    }
                    deck = newDeck; //колода стала на одну карту меньше
                    Array.Resize(ref newDeck, deck.Length - 1);
                    Array.Clear(newDeck, 0, newDeck.Length); //очищаем массив

                    //компьютер берет себе карту

                    shuffle = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                    dealerHand[dealerHand.Length - 1] = deck[shuffle]; //присваиваем карту дилеру                             
                    for (int i = 0; i < shuffle; i++) // удаляем из колоды вытянутую карту
                    {
                        newDeck[i] = deck[i];
                    }
                    for (int i = shuffle; i < deck.Length - 1; i++)
                    {
                        newDeck[i] = deck[i + 1];
                    }
                    deck = newDeck; //колода стала на одну карту меньше
                    Array.Resize(ref newDeck, deck.Length - 1); //укорачиваем массив на один элемент
                    Array.Clear(newDeck, 0, newDeck.Length); //очищаем массив

                    Console.Write(phraseYourHand); //выводим руку игрока на экран
                    for (int i = 0; i < playerHand.Length; i++)
                    {
                        Console.Write(playerHand[i] + " ");
                    }
                    Console.WriteLine();

                    bool dealerPas = false;
                    bool playerPas = false;
                    int summDealerHand;
                    int summPlayerHand;

                    do
                    {
                        do
                        {                        
                            Console.Write(questionMore);
                            answer = Console.ReadLine();
                        } while (answer != "y" && answer != "n");
                        if (answer == "y")
                        {
                            //сдаем карту игроку
                            Array.Resize(ref playerHand, playerHand.Length + 1); //увеличиваем массив на 1 элемент
                            shuffle = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                            playerHand[playerHand.Length - 1] = deck[shuffle]; //присваиваем карту игроку                                                          
                            for (int i = 0; i < shuffle; i++) //удаляем из колоды вытянутую карту
                            {
                                newDeck[i] = deck[i];
                            }
                            for (int i = shuffle; i < deck.Length - 1; i++)
                            {
                                newDeck[i] = deck[i + 1];
                            }
                            deck = newDeck; //колода стала на одну карту меньше
                            Array.Resize(ref newDeck, deck.Length - 1); //укорачиваем массив на один элемент
                            Array.Clear(newDeck, 0, newDeck.Length); //очищаем массив

                            summDealerHand = 0;
                            foreach (int item in dealerHand)
                            {
                                if (item == 11 && (summDealerHand+11) > 21) //Если с тузом перебор то туз равен 1
                                {
                                    summDealerHand = summDealerHand + 1;
                                }
                                else summDealerHand = summDealerHand + item;
                            }

                            if (summDealerHand < 16)
                            {
                                //компьютер берет себе карту

                                Array.Resize(ref dealerHand, dealerHand.Length + 1); //увеличиваем массив на 1 элемент
                                shuffle = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                                dealerHand[dealerHand.Length - 1] = deck[shuffle]; //присваиваем карту дилеру                             
                                for (int i = 0; i < shuffle; i++) // удаляем из колоды вытянутую карту
                                {
                                    newDeck[i] = deck[i];
                                }
                                for (int i = shuffle; i < deck.Length - 1; i++)
                                {
                                    newDeck[i] = deck[i + 1];
                                }
                                deck = newDeck; //колода стала на одну карту меньше
                                Array.Resize(ref newDeck, deck.Length - 1); //укорачиваем массив на один элемент
                                Array.Clear(newDeck, 0, newDeck.Length); //очищаем массив
                            }
                            else
                            {

                                dealerPas = true;
                                Console.WriteLine(phraseDealerPas);
                            }


                            Console.Write(phraseYourHand); //выводим руку игрока на экран
                            for (int i = 0; i < playerHand.Length; i++)
                            {
                                Console.Write(playerHand[i] + " ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            playerPas = true;
                            summDealerHand = 0;
                            foreach (int item in dealerHand)
                            {
                                if (item == 11 && (summDealerHand + 11) > 21) //Если с тузом перебор то туз равен 1
                                {
                                    summDealerHand = summDealerHand + 1;
                                }
                                else summDealerHand = summDealerHand + item;
                            }
                            while (summDealerHand < 16)
                            {
                                //компьютер берет себе карту

                                Array.Resize(ref dealerHand, dealerHand.Length + 1); //увеличиваем массив на 1 элемент
                                shuffle = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                                dealerHand[dealerHand.Length - 1] = deck[shuffle]; //присваиваем карту дилеру                             
                                for (int i = 0; i < shuffle; i++) // удаляем из колоды вытянутую карту
                                {
                                    newDeck[i] = deck[i];
                                }
                                for (int i = shuffle; i < deck.Length - 1; i++)
                                {
                                    newDeck[i] = deck[i + 1];
                                }
                                deck = newDeck; //колода стала на одну карту меньше
                                Array.Resize(ref newDeck, deck.Length - 1); //укорачиваем массив на один элемент
                                Array.Clear(newDeck, 0, newDeck.Length); //очищаем массив
                                summDealerHand = 0;
                                foreach (int item in dealerHand)
                                {
                                    if (item == 11 && (summDealerHand + 11) > 21) //Если с тузом перебор то туз равен 1
                                    {
                                        summDealerHand = summDealerHand + 1;
                                    }
                                    else summDealerHand = summDealerHand + item;
                                }

                            }
                            dealerPas = true;
                        }
                    } while (playerPas == false || dealerPas == false);

                    summDealerHand = 0;
                    summPlayerHand = 0;

                    Console.Write(phraseYourHand); //выводим руку игрока на экран
                    for (int i = 0; i < playerHand.Length; i++)
                    {
                        if (playerHand[i] == 11 && (summPlayerHand + playerHand[i]) > 21) //Если с тузом перебор то туз равен 1
                        {
                            summPlayerHand = summPlayerHand + 1;
                        }
                        else summPlayerHand = summPlayerHand + playerHand[i];
                        Console.Write(playerHand[i] + " ");
                    }
                    Console.Write("(" + summPlayerHand + ")");
                    Console.WriteLine();

                    Console.Write(phraseDealerHand); //выводим руку дилера на экран
                    for (int i = 0; i < dealerHand.Length; i++)
                    {
                        if (dealerHand[i] == 11 && (summDealerHand + dealerHand[i]) > 21) //Если с тузом перебор то туз равен 1
                        {
                            summDealerHand = summDealerHand + 1;
                        }
                        else summDealerHand = summDealerHand + dealerHand[i];
                        Console.Write(dealerHand[i] + " ");
                    }
                    Console.Write("(" + summDealerHand + ")");
                    Console.WriteLine();

                    if (summDealerHand > 21 || summPlayerHand == 21) summDealerHand = 0;
                    if (summPlayerHand > 21) summPlayerHand = 0;
                    if (summDealerHand > summPlayerHand || summDealerHand == summPlayerHand)
                    {
                        summPlayerHand = 0;
                    }

                    if (summDealerHand >= summPlayerHand)
                    {
                        Console.WriteLine(phraseYouLose);
                    }
                    else
                    {
                        Console.WriteLine(phraseYouWin);
                    }
                    do
                    {
                        Console.Write(questionPlayAgain);
                        answer = Console.ReadLine();
                    } while (answer != "y" && answer != "n");
                    
                    if (answer == "y")
                    {
                        againGameAttribute = true;
                    }


                }
                else againGameAttribute = false;
            } while (againGameAttribute);
        }
    }
}
