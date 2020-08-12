using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackDomain.GameUtilities
{
    public class Dealer
    {
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
        public bool CanStopHitting
        {
            get
            {
                return TotalCardsValue >= 16;
            }
        }
        public Dealer()
        {
            Cards = new List<Card>();
        }

        public void DealNewGame(Card displayCard, Card hiddenCard)
        {
            Cards.Add(displayCard);
            Cards.Add(hiddenCard);
        }

        public void Hit(Card card)
        {
            Cards.Add(card);
        }

        public void ResetCards()
        {
            Cards = new List<Card>();
        }

    }
}
