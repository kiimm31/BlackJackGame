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
                    int AceIsOne = 0;
                    int AceIsEleven = 0;
                    // Ace = 1
                    foreach (Card card in Cards)
                    {
                        AceIsOne += card.CardValue == PublicEnums.CardValue.Ace ? 1 : card.Value;
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
