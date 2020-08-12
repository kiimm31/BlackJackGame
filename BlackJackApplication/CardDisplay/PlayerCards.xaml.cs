using BlackJackDomain.GameUtilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace BlackJackApplication.CardDisplay
{
    /// <summary>
    /// Interaction logic for PlayerCards.xaml
    /// </summary>
    public partial class PlayerCards : UserControl /*, INotifyPropertyChanged*/
    {
        private readonly Player _player;

        public delegate Card HitPlayerDelegate(bool isHidden);
        public HitPlayerDelegate HitPlayer = null;

        public delegate void StayPlayerDelegate();
        public StayPlayerDelegate StayPlayer = null;

        //public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Card> _cards => new ObservableCollection<Card>(_player.Cards);
        public ObservableCollection<Card> Cards
        {
            get { return _cards; }
        }
        public PlayerCards(Player player)
        {
            InitializeComponent();
            _player = player;
            this.DataContext = this;
            OnLoad(false);
        }

        private void OnLoad(bool canStartGame)
        {
            txtPlayerName.Text = _player.PlayerName;
            txtPlayerScore.Text = $"Score : {_player.Points.ToString()}";

            CardDataGrid.DataContext = Cards;

            btnHitPlayer.IsEnabled = canStartGame;
            btnStayPlayer.IsEnabled = canStartGame;
        }

        private void btnHitPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (HitPlayer != null)
            {
                _player.Hit(HitPlayer(false));
            }

            OnLoad(true);

            if (_player.TotalCardsValue > 21)
            {
                btnHitPlayer.IsEnabled = false;
            }
            else if (_player.TotalCardsValue < 16)
            {
                btnStayPlayer.IsEnabled = false;
            }

        }

        private void btnStayPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (StayPlayer != null)
                StayPlayer();
            OnLoad(false);
        }

        public void NewGame(Card card1, Card card2)
        {
            _player.DealNewGame(card1, card2);
            OnLoad(true);

            if (_player.TotalCardsValue > 21)
            {
                btnHitPlayer.IsEnabled = false;
            }
            else if (_player.TotalCardsValue < 16)
            {
                btnStayPlayer.IsEnabled = false;
            }
        }
    }
}
