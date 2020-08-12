using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackDomain.GameUtilities
{
    public class PublicEnums
    {
        public enum Suit
        {
            Diamond = 1,
            Club = 2,
            Heart = 3,
            Spade = 4
        }
        public enum Turn
        {
            notSet = 0,
            Dealer = 1,
            Player = 2
        }

        public enum CardValue
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }
    }
}
