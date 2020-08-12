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
                    int AceIsOne = 0;
                    int AceIsEleven = 0;
                    // Ace = 1
                    foreach (Card card in Cards)
                    {
                        AceIsOne += card.CardValue == PublicEnums.CardValue.Ace? 1: card.Value;
                        AceIsEleven += card.CardValue == PublicEnums.CardValue.Ace ? 11 : card.Value;
                    }

                    return AceIsEleven > 21 ? AceIsOne : AceIsEleven; // if ace is eleven and more than 21, -> more benefit to count as 1
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
