using System;
using System.Collections.Generic;
using System.Text;
using static BlackJackDomain.GameUtilities.PublicEnums;

namespace BlackJackDomain.GameUtilities
{
    public class Card
    {
        public int Value
        {
            get
            {
                if ((int)CardValue > 10)
                {
                    return 10;
                }
                else
                    return (int)CardValue;
            }
        }
        public bool IsHidden { get; set; }
        public Suit Suit { get; set; }
        public bool HasDealt { get; set; }
        public CardValue CardValue { get; set; }

        public Card()
        {

        }

    }
}
