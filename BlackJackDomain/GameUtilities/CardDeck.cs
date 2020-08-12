using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BlackJackDomain.GameUtilities.PublicEnums;

namespace BlackJackDomain.GameUtilities
{
    public class CardDeck
    {
        private readonly int _noOfDecks;
        public List<Card> Cards { get; set; }
        public bool NeedsReshuffle
        {
            get
            {
                return Cards.Count(x => x.HasDealt == false) < 15;
            }
        }
        protected CardDeck()
        {
            Cards = new List<Card>();
        }

        public CardDeck(int noOfDecks) : this()
        {
            _noOfDecks = noOfDecks;
            LoadNewDeck();
        }

        private bool LoadNewDeck()
        {
            if (_noOfDecks > 0)
            {
                for (int i = 0; i < _noOfDecks; i++)
                {
                    foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                    {
                        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                        {
                            Cards.Add(new Card() { CardValue = (CardValue)cardValue, Suit = (Suit)suit, IsHidden = true, HasDealt = false });
                        }
                    }
                }

                return true;
            }
            return false;
        }

        public bool ShuffleDeck()
        {
            if (Cards?.Any() ?? false)
            {
                Cards.ForEach((x) => x.HasDealt = false);

                Random random = new Random();

                int totalCards = Cards.Count();

                while (totalCards > 1)
                {
                    totalCards--;
                    int k = random.Next(totalCards + 1);
                    Card value = Cards[k];
                    Cards[k] = Cards[totalCards];
                    Cards[totalCards] = value;
                }

                return true;
            }

            return false;
        }

        public Card GetCard(bool isHidden)
        {
            Card returnCard = Cards.FirstOrDefault(x => x.HasDealt == false);

            if (returnCard != null)
            {
                returnCard.HasDealt = true;

                returnCard.IsHidden = isHidden;

                return returnCard;
            }

            return null;
        }
    }
}
