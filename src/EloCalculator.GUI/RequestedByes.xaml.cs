namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for RequestedByes.xaml.
    /// </summary>
    public partial class RequestedByes : Window
    {
        private Tournament Tournament { get; set; }

        private TournamentRound TournamentRound { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestedByes"/> class.
        /// </summary>
        /// <param name="tournament">The <see cref="Tournament"/> the bye is from.</param>
        /// <param name="round">The <see cref="TournamentRound"/> the bye is from.</param>
        public RequestedByes(Tournament tournament, TournamentRound round)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            this.TournamentRound = round;
            Utility.UpdateAll();
            this.DataGrid.ItemsSource = this.TournamentRound.RequestedByes;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        /// <summary>
        /// Delete requested byes when the DEL key is pressed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Key == Key.Delete)
            {
                foreach (TournamentPlayer player in grid.SelectedItems)
                {
                    this.TournamentRound.RequestedByes.Remove(player);
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
        }
    }
}
