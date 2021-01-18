using System;

namespace RussianBlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            bool answer = false;
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
                    answer = question(questionPlay);
                }

                if (answer)
                {
                    int[] dealerHand = new int[0];
                    int[] playerHand = new int[0];
                    bool dealerPas = false;
                    bool playerPas = false;
                    bool winHand = false;
                    bool playerWinHand = false;
                    bool dealerWinHand = false;
                    int summDealerHand;
                    int summPlayerHand;

                    GetCard(ref deck, ref playerHand);

                    GetCard(ref deck, ref dealerHand);

                    PrintHand(phrasePlayerHand, playerHand);
                    Console.WriteLine();

                    do
                    {
                        answer = question(questionMore);

                        if (answer == true && playerHand.Length < 20)
                        {
                            GetCard(ref deck, ref playerHand);

                            summDealerHand = GetSumHand(dealerHand, out winHand);

                            if (summDealerHand < 16)
                            {
                                GetCard(ref deck, ref dealerHand);
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
                                GetCard(ref deck, ref dealerHand);
                                summDealerHand = GetSumHand(dealerHand, out winHand);
                            }
                            dealerPas = true;
                        }
                    } while (playerPas == false || dealerPas == false);

                    summPlayerHand = GetSumHand(playerHand, out winHand);

                    if (winHand == true)
                    {
                        playerWinHand = true;
                        winHand = false;
                    }

                    PrintHand(phrasePlayerHand, playerHand);
                    Console.Write("(" + summPlayerHand + ")");
                    Console.WriteLine();

                    summDealerHand = GetSumHand(dealerHand, out winHand);

                    if (winHand == true)
                    {
                        dealerWinHand = true;
                        winHand = false;
                    }

                    PrintHand(phraseDealerHand, dealerHand);
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
                    
                    answer = question(questionPlayAgain);

                    if (answer)
                    {
                        againGameAttribute = true;
                    }


                }
                else againGameAttribute = false;
            } while (againGameAttribute);
        }
        private static bool question(string questionPlayAgain)
        {
            string answer;
            do
            {
                Console.Write(questionPlayAgain);
                answer = Console.ReadLine();
            } while (answer != "y" && answer != "n");
            
            if (answer == "y")
            {
                return true;
            }
            else return false;
        }

        private static void GetCard(ref int[] deck, ref int[] gamerHand)
        {
            Random random = new Random();
            int card;
            Array.Resize(ref gamerHand, gamerHand.Length + 1);

            card = random.Next(0, deck.Length); //вытаскиваем из колоды случайную карту

            gamerHand[gamerHand.Length - 1] = deck[card]; //присваиваем карту игроку                                                          

            deck = RemoveCardFromDeck(deck, card);           
        }

        private static void PrintHand(string phraseYourHand, int[] gamerHand)
        {
            Console.Write(phraseYourHand);
            for (int i = 0; i < gamerHand.Length; i++)
            {
                Console.Write(gamerHand[i] + " ");
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
