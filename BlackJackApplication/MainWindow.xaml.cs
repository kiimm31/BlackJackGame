using BlackJackDomain;
using BlackJackDomain.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJackApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            Player player = null;
            CardDeck cardDeck = null;
            Dealer dealer = new Dealer();

            if (!string.IsNullOrWhiteSpace(txtPlayerName.Text))
            {
                player = new Player(txtPlayerName.Text);

                int deck = 1;

                if (!string.IsNullOrWhiteSpace(txtNumberOfDeck.Text))
                {
                    int.TryParse(txtNumberOfDeck.Text, out deck);

                    cardDeck = new CardDeck(deck);
                    cardDeck.ShuffleDeck();
                }

                if (player != null && cardDeck != null)
                {
                    BlackJackGame game = new BlackJackGame(cardDeck, dealer, player);

                    MainGameInterface mainGameInterface = new MainGameInterface(game);

                    this.Content = mainGameInterface;
                }
            }
        }
    }
}
