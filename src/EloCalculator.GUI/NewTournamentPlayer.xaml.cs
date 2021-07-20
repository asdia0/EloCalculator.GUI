namespace EloCalculator.GUI
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewTournamentPlayer.xaml.
    /// </summary>
    public partial class NewTournamentPlayer : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTournamentPlayer"/> class.
        /// </summary>
        public NewTournamentPlayer()
        {
            this.InitializeComponent();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Player.ItemsSource = Utility.Players.Select(i => $"{i.ID} ({i.Name})");
        }

        /// <summary>
        /// Adds a <see cref="TournamentPlayer"/> to a <see cref="Tournament"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            Tournament tournament = Utility.Tournaments[this.Tournament.SelectedIndex];
            Player player = Utility.Players[this.Player.SelectedIndex];

            if (tournament.Players.Where(i => i.Player == player).Any())
            {
                Popup popup = Utility.CreatePopup($"Player {player.ID} ({player.Name}) has already been added to Tournament {tournament.ID} ({tournament.Name}).");
                popup.IsOpen = true;
            }
            else
            {
                _ = new TournamentPlayer(tournament, player);
                this.Close();
            }
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
