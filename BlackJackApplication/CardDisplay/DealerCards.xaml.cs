using BlackJackDomain.GameUtilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Linq;
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
using static BlackJackDomain.GameUtilities.PublicEnums;

namespace BlackJackApplication.CardDisplay
{
    /// <summary>
    /// Interaction logic for DealerCards.xaml
    /// </summary>
    public partial class DealerCards : UserControl
    {
        private readonly Dealer _dealer;

        public delegate void StartDealerDelegate();
        public StartDealerDelegate StartDealer = null;

        private ObservableCollection<Card> _cards => new ObservableCollection<Card>(_dealer.Cards.Where(x => x.IsHidden == false));
        public ObservableCollection<Card> Cards
        {
            get { return _cards; }
        }

        public DealerCards(Dealer dealer)
        {
            InitializeComponent();
            _dealer = dealer;
            this.DataContext = this;
            OnLoad(true);
        }

        private void OnLoad(bool canStartGame)
        {
            txtResult.Text = "";
            CardDataGrid.DataContext = Cards;
            btnNewGame.IsEnabled = canStartGame;

        }

        public void UpdateResult(Turn Winner, int cardsRemainding)
        {
            _dealer.Cards.ForEach((x) => x.IsHidden = false);

            OnLoad(true);
            btnNewGame.ToolTip = $"Cards Remaining in Deck: {cardsRemainding}";
            switch (Winner)
            {
                case Turn.Dealer:
                    txtResult.Text = "GG You Lose!!";
                    break;
                case Turn.Player:
                    txtResult.Text = "Oh No You Beat ME!!";
                    break;
                case Turn.notSet:
                    txtResult.Text = "GGWP Next..";
                    break;
                default:
                    break;
            }
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (StartDealer != null)
            {
                btnNewGame.IsEnabled = false;
                StartDealer();
            }
            OnLoad(false);
        }

        public void NewGame(Card card1, Card card2)
        {
            _dealer.DealNewGame(card1, card2);
            OnLoad(false);
        }
    }
}
