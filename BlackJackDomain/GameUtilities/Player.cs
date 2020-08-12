using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BlackJackDomain.GameUtilities
{
    public class Player
    {
        public readonly string PlayerName;
        public int Points { get; set; }
        public List<Card> Cards { get; set; }
        public int TotalCardsValue
        {
            get
            {
                if (Cards?.Any() ?? false)
                {
                    int returnInt = 0;
                    foreach (Card card in Cards)
                    {
                        returnInt += card.Value;
                    }

                    return returnInt;
                }
                return 0;
            }
        }
        public bool IsBusted
        {
            get
            {
                return TotalCardsValue > 21;
            }
        }

        private int _noOfGamesPlayed;
        public Player()
        {
            Cards = new List<Card>();
            Points = 0;
            _noOfGamesPlayed = 0;
        }

        public Player(string playerName) : this()
        {
            PlayerName = playerName;
        }

        public void ResetCards()
        {
            Cards = new List<Card>();
            _noOfGamesPlayed += 1;
        }

        public void DealNewGame(Card card1, Card card2)
        {
            Cards.Add(card1);
            Cards.Add(card2);
        }

        public void Hit(Card card)
        {
            Cards.Add(card);
        }

        public void Lose()
        {
            Points -= 10;
        }

        public void Win()
        {
            bool isBlackJack = false;

            if (Cards.Count() == 2 && TotalCardsValue == 21)
            {
                isBlackJack = true;
            }

            if (isBlackJack)
            {
                Points += 15;
            }
            else
            {
                Points += 10;
            }
        }

        public void Push()
        {
            Points += 0;
        }

    }
}
