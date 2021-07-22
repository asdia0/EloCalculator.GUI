namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for TournamentRoundGames.xaml.
    /// </summary>
    public partial class TournamentRoundGames : Window
    {
        public Tournament Tournament { get; set; }

        public TournamentRound TournamentRound { get; set; }

        public TournamentRoundGames(Tournament tournament, TournamentRound round)
        {
            this.InitializeComponent();
            this.Title = $"EloCalculator: {tournament.Name} Round {round.ID}'s Games";
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            this.TournamentRound = round;
            Utility.UpdateAll();
            this.DataGrid.ItemsSource = Utility.TournamentRoundGames[this.Tournament][this.TournamentRound];
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        /// <summary>
        /// Delete <see cref="Game"/>s when the DEL key is pressed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Key == Key.Delete)
            {
                foreach (Game game in grid.SelectedItems)
                {
                    this.TournamentRound.Games.Remove(game);
                }
            }

            // TODO: Reload databases

            Utility.UpdateAll();
        }
    }
}
