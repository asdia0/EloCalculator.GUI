namespace EloCalculator.GUI
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for TournamentPlayerGames.xaml.
    /// </summary>
    public partial class TournamentPlayerGames : Window
    {
        private Tournament Tournament { get; set; }

        private TournamentPlayer TournamentPlayer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentPlayerGames"/> class.
        /// </summary>
        /// <param name="tournament">The <see cref="EloCalculator.Tournament"/> the <see cref="EloCalculator.TournamentPlayer"/> is from.</param>
        /// <param name="player">The <see cref="EloCalculator.TournamentPlayer"/> to display.</param>
        public TournamentPlayerGames(Tournament tournament, TournamentPlayer player)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            this.TournamentPlayer = player;
            this.DataGrid.ItemsSource = Utility.TournamentPlayerGames[this.Tournament][this.TournamentPlayer];
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
                    GameDatabase.Games.Remove(game);
                }
            }

            // TODO: Reload databases.
        }
    }
}
