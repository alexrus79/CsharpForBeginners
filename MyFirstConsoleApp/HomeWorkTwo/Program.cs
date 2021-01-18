﻿using System;

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
            string phrasePlayerHand = "У Вас в руке: ";
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
                    bool dealerPas = false;
                    bool playerPas = false;
                    bool winHand = false;
                    bool playerWinHand = false;
                    bool dealerWinHand = false;
                    int summDealerHand;
                    int summPlayerHand;

                    int card = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                    
                    playerHand[playerHand.Length - 1] = deck[card]; //присваиваем карту игроку                                                          

                    deck = RemoveCardFromDeck(deck, card);

                    card = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                    
                    dealerHand[dealerHand.Length - 1] = deck[card]; //присваиваем карту дилеру                             

                    deck = RemoveCardFromDeck(deck, card);
                    
                    PrintHand(phrasePlayerHand, playerHand);
                    Console.WriteLine();

                    do
                    {
                        do
                        {
                            Console.Write(questionMore);
                            answer = Console.ReadLine();
                        } while (answer != "y" && answer != "n");
                        
                        if (answer == "y" && playerHand.Length < 20)
                        {                            
                            //сдаем карту игроку
                            Array.Resize(ref playerHand, playerHand.Length + 1); //увеличиваем массив на 1 элемент
                            
                            card = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                            
                            playerHand[playerHand.Length - 1] = deck[card]; //присваиваем карту игроку                                                          

                            deck = RemoveCardFromDeck(deck, card);

                            summDealerHand = GetSumHand(dealerHand, out winHand);

                            if (summDealerHand < 16)
                            {
                                //компьютер берет себе карту

                                Array.Resize(ref dealerHand, dealerHand.Length + 1); //увеличиваем массив на 1 элемент
                                
                                card = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                                
                                dealerHand[dealerHand.Length - 1] = deck[card]; //присваиваем карту дилеру                             

                                deck = RemoveCardFromDeck(deck, card);
                            }
                            else
                            {
                                dealerPas = true;
                                Console.WriteLine(phraseDealerPas);
                            }
                            PrintHand(phrasePlayerHand, playerHand);
                            Console.WriteLine();
                        }
                        else
                        {
                            playerPas = true;

                            summDealerHand = GetSumHand(dealerHand, out winHand);

                            while (summDealerHand < 16)
                            {
                                //компьютер берет себе карту

                                Array.Resize(ref dealerHand, dealerHand.Length + 1); //увеличиваем массив на 1 элемент
                                
                                card = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту
                                
                                dealerHand[dealerHand.Length - 1] = deck[card]; //присваиваем карту дилеру                             

                                deck = RemoveCardFromDeck(deck, card);

                                summDealerHand = GetSumHand(dealerHand, out winHand);
                            }
                            dealerPas = true;
                        }
                    } while (playerPas == false || dealerPas == false);

                    PrintHand(phrasePlayerHand, playerHand);

                    summPlayerHand = GetSumHand(playerHand, out winHand);

                    if (winHand == true)
                    {
                        playerWinHand = true;
                        winHand = false;
                    }

                    Console.Write("(" + summPlayerHand + ")");
                    Console.WriteLine();

                    PrintHand(phraseDealerHand, dealerHand);

                    summDealerHand = GetSumHand(dealerHand, out winHand);

                    if (winHand == true)
                    {
                        dealerWinHand = true;
                        winHand = false;
                    }

                    Console.Write("(" + summDealerHand + ")");
                    Console.WriteLine();
                    if (playerWinHand == true && dealerWinHand == false)
                    {
                        //Если у игрока два туза или пять картинок, то исключить все проверки
                    }
                    else if (dealerWinHand == true && playerWinHand == false)
                    {
                        //Если у дилера два туза или пять картинок, то исключить все проверки
                    }
                    else if (dealerWinHand == true && playerWinHand == true)
                    {
                        playerWinHand = false; //Если у обоих игроков по туза или по пять картинок, то выиграл дилер
                    }
                    else if (summDealerHand > 21 || summPlayerHand == 21)
                    {
                        playerWinHand = true;
                    }
                    else if (summPlayerHand > 21 || 
                        summDealerHand > summPlayerHand || 
                        summDealerHand == summPlayerHand)
                    {
                        dealerWinHand = true;
                    } 
                    
                    if (dealerWinHand == true && playerWinHand == false)
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

        private static void PrintHand(string phraseYourHand, int[] playerHand)
        {
            Console.Write(phraseYourHand);
            for (int i = 0; i < playerHand.Length; i++)
            {
                Console.Write(playerHand[i] + " ");
            }
            
        }

        private static int[] RemoveCardFromDeck(int[] deck, int index)
        {

            int[] newDeck = new int[deck.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newDeck[i] = deck[i];
            }
            for (int i = index; i < deck.Length - 1; i++)
            {
                newDeck[i] = deck[i + 1];
            }
            return newDeck;
        }

        private static int GetSumHand(int[] Hand, out bool winHand)
        {
            int sum = 0;
            bool fiveCardImade = true;
            winHand = false;

            for (int i = 0; i < Hand.Length; i++)
            {
                if (sum == 11 && Hand[i] == 11 && i == 1)
                {
                    sum = 21;
                    winHand = true;
                    break;
                } 

                if (Hand[i] == 11 && (sum + 11) > 21) //Если с тузом перебор то туз равен 1
                {
                    sum = sum + 1;
                }
                else sum = sum + Hand[i];
                
                if (Hand[i] > 4) fiveCardImade = false;
            }

            if (fiveCardImade && Hand.Length == 5)
            {
                sum = 21; //усли все картинки и их пять то рука выигрышная
                winHand = true;
            }
            
            return sum;
        }
    }
}
