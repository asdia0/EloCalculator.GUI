namespace EloCalculator.GUI
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for TournamentPlayers.xaml.
    /// </summary>
    public partial class TournamentPlayers : Window
    {
        private Tournament Tournament { get; set; }

        private ObservableCollection<TournamentPlayer> Players { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentPlayers"/> class.
        /// </summary>
        /// <param name="tournament">The <see cref="EloCalculator.Tournament"/> the <see cref="TournamentPlayer"/>s are from.</param>
        public TournamentPlayers(Tournament tournament)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            this.Players = Utility.TournamentPlayers[this.Tournament];
            this.DataGrid.ItemsSource = this.Players;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        /// <summary>
        /// Delete <see cref="TournamentPlayer"/>s when the DEL key is pressed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Key == Key.Delete)
            {
                foreach (TournamentPlayer tournamentPlayer in grid.SelectedItems)
                {
                    // Remove games the player played.
                    foreach (TournamentRound round in this.Tournament.Rounds)
                    {
                       round.Games.RemoveWhere(i => i.WhitePlayer == tournamentPlayer.Player || i.BlackPlayer == tournamentPlayer.Player);
                    }

                    // Remove player from the database.
                    this.Tournament.Players.Remove(tournamentPlayer);
                }
            }

            // TODO: Reload databases.
        }

        /// <summary>
        /// Opens <see cref="TournamentPlayerGames"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentPlayerGames tpg = new(this.Tournament, ((Button)sender).DataContext as TournamentPlayer);
            tpg.Show();
            Window.GetWindow(this).Close();
        }
    }
}
