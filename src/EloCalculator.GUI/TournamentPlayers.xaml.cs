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
        public Tournament Tournament { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentPlayers"/> class.
        /// </summary>
        /// <param name="tournament">The <see cref="EloCalculator.Tournament"/> the <see cref="TournamentPlayer"/>s are from.</param>
        public TournamentPlayers(Tournament tournament)
        {
            this.InitializeComponent();
            this.Title = $"EloCalculator: {tournament.Name}'s Players";
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            Utility.UpdateAll();
            this.DataGrid.ItemsSource = this.Tournament.Players.Distinct();
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

            Utility.UpdateAll();
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
