using BlackJackApplication.CardDisplay;
using BlackJackDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlackJackDomain.GameUtilities;
using static BlackJackDomain.GameUtilities.PublicEnums;

namespace BlackJackApplication
{
    /// <summary>
    /// Interaction logic for MainGameInterface.xaml
    /// </summary>
    public partial class MainGameInterface : UserControl
    {
        public readonly BlackJackGame Game;
        private DealerCards _dealerCards;
        private PlayerCards _playerCards;
        public MainGameInterface(BlackJackGame game)
        {
            InitializeComponent();
            Game = game;
            onLoad();
        }

        private void onLoad()
        {
            gameGrid.Children.Clear();
            Game.GetDealer().ResetCards();
            Game.GetPlayer().ResetCards();

            //DealerPart
            _dealerCards = new DealerCards(Game.GetDealer());
            _dealerCards.StartDealer = new DealerCards.StartDealerDelegate(NewGame);
            Grid.SetRow(_dealerCards, 0);
            Grid.SetColumn(_dealerCards, 0);

            gameGrid.Children.Add(_dealerCards);

            //PlayerPart

            _playerCards = new PlayerCards(Game.GetPlayer());
            _playerCards.HitPlayer = new PlayerCards.HitPlayerDelegate(Game.GetDeck().GetCard);
            _playerCards.StayPlayer = new PlayerCards.StayPlayerDelegate(PlayerStayed);

            Grid.SetRow(_playerCards, 1);
            Grid.SetColumn(_playerCards, 0);
            gameGrid.Children.Add(_playerCards);
        }

        public void NewGame()
        {
            if (Game.GetDeck().NeedsReshuffle)
            {
                Game.GetDeck().ShuffleDeck();
            }

            onLoad();

            _playerCards.NewGame(Game.GetDeck().GetCard(false), Game.GetDeck().GetCard(false));
            _dealerCards.NewGame(Game.GetDeck().GetCard(false), Game.GetDeck().GetCard(true));
        }

        public void PlayerStayed()
        {
            Dealer dealer = Game.GetDealer();
            Player player = Game.GetPlayer();

            Turn winner = Turn.notSet;
            if (player.IsBusted)
            {
                //player lost already
                //dealer can giveup
                player.Lose();
                winner = Turn.Dealer;
            }
            else
            {
                while (!(dealer.CanStopHitting && !dealer.IsBusted))
                {
                    dealer.Hit(Game.GetDeck().GetCard(false));
                }

                //tabulate who won
                if (dealer.IsBusted)
                {
                    player.Win();
                    winner = Turn.Player;
                }
                else if (dealer.TotalCardsValue < player.TotalCardsValue)
                {
                    player.Win();
                    winner = Turn.Player;
                }
                else if (dealer.TotalCardsValue == player.TotalCardsValue)
                {
                    player.Push();
                    winner = Turn.notSet;
                }
                else if (dealer.TotalCardsValue > player.TotalCardsValue)
                {
                    player.Lose();
                    winner = Turn.Dealer;
                }
            }
            _dealerCards.UpdateResult(winner);
        }
    }
}
