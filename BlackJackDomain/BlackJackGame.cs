using BlackJackDomain.GameUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using static BlackJackDomain.GameUtilities.PublicEnums;

namespace BlackJackDomain
{
    public class BlackJackGame
    {
        private readonly CardDeck _cardDeck;
        private readonly Dealer _dealer;
        private readonly Player _player;
        private Turn _turn;

        protected BlackJackGame()
        {
            _turn = Turn.Player;
        }

        public BlackJackGame(CardDeck cardDeck, Dealer dealer, Player player): this()
        {
            _cardDeck = cardDeck;
            _dealer = dealer;
            _player = player;
        }

        public void EndGame()
        {

        }

        public void StartGame()
        {

        }

        public Dealer GetDealer()
        {
            return _dealer;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public CardDeck GetDeck()
        {
            return _cardDeck;
        }
    }
}
