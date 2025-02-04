using System;
using System.Collections;
using System.Formats.Asn1;
using System.Runtime.Serialization;

namespace L20250204
{
    internal class Program
    {

        static void Initialize(ref int[] deck)
        {
            
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }
        }

        static void Shuffle(int[] deck)
        {
            Random random = new Random();

            for (int i = 0; i < deck.Length * 10; ++i)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);

                int temp = deck[firstCardIndex];
                deck[firstCardIndex] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }
        }

        enum CardType
        {
            None = -1,
            Heart = 0,
            Diamond = 1,
            Clover = 2,
            Spade = 3,
        }

        static int GetScore(int cardNumber)
        {
            int value = (((cardNumber - 1) % 13) + 1);
            return value > 10 ? 10 : value;
        }

        static void PrintCardList(int[] deck)
        {
            //Computer
            Console.WriteLine("Computer");
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])}");
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Player");
            for (int i = 3; i < 6; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])}");
            }
            Console.WriteLine("-------------");
        }

        static void Print(int[] deck)
        {
            PrintCardList(deck);

            int computerScore = GetScore(deck[0]) +
                GetScore(deck[1]) + GetScore(deck[2]);
            int playerScore = GetScore(deck[3]) + GetScore(deck[4])
                + GetScore(deck[5]);

            Console.WriteLine($"Computer score : {computerScore}, Player Score : {playerScore}");

            if (playerScore >= 21 && computerScore < 21)
            {
                //Computer Win
                Console.WriteLine("Computer Win");
            }
            else if (playerScore < 21 && computerScore >= 21)
            {
                //Player Win
                Console.WriteLine("Player Win");
            }
            else if (playerScore >= 21 && computerScore >= 21)
            {
                //Player Win
                Console.WriteLine("Player Win");
            }
            else if (computerScore <= playerScore)
            {
                //Player Win
                Console.WriteLine("Player Win");
            }
            else // (computerScore > playerScore)
            {
                //Computer Win
                Console.WriteLine("Computer Win");
            }
        }

        static CardType CheckCardType(int cardNumber)
        {
            int valueType = (cardNumber - 1) / 13;

            //CardType returnCardType = (CardType)valueType;
            //switch((CardType)valueType)
            //{
            //    case CardType.Heart:
            //        returnCardType = CardType.Heart;
            //        break;
            //    case CardType.Diamond:
            //        returnCardType = CardType.Diamond;
            //        break;
            //    case CardType.Spade:
            //        returnCardType = CardType.Spade;
            //        break;
            //    case CardType.Clover:
            //        returnCardType = CardType.Clover;
            //        break;
            //    default:
            //        returnCardType = CardType.None;
            //        break;
            //}

            return (CardType)valueType;
        }

        static string CheckCardName(int cardNumber)
        {

            //1 - 13
            int cardValue = ((cardNumber - 1) % 13) + 1;
            string cardName;
            switch (cardValue)
            {
                case 1:
                    cardName = "A";
                    break;
                case 11:
                    cardName = "J";
                    break;
                case 12:
                    cardName = "Q";
                    break;
                case 13:
                    cardName = "K";
                    break;
                default:
                    cardName = cardValue.ToString();
                    break;
            }

            return cardName;
        }

        static void Main(string[] args)
        {
            int[] deck = new int[52];

            Initialize(ref deck);

            Shuffle(deck);

            Print(deck);
        }

    }
}

