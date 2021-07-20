namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for TournamentRounds.xaml.
    /// </summary>
    public partial class TournamentRounds : Window
    {
        public Tournament Tournament { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentRounds"/> class.
        /// </summary>
        /// <param name="tournament">The <see cref="EloCalculator.Tournament"/> to display.</param>
        public TournamentRounds(Tournament tournament)
        {
            this.InitializeComponent();
            this.Title = $"EloCalculator: {tournament.Name}'s Rounds";
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            Utility.UpdateAll();
            this.DataGrid.ItemsSource = Utility.TournamentRounds[this.Tournament];
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        /// <summary>
        /// Delete <see cref="TournamentRound"/>s when the DEL key is pressed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Key == Key.Delete)
            {
                foreach (TournamentRound rounds in grid.SelectedItems)
                {
                    this.Tournament.Rounds.Remove(rounds);
                }
            }

            // TODO: Reload databases

            Utility.UpdateAll();
        }

        /// <summary>
        /// Opens <see cref="TournamentRoundGames"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentRoundGames trg = new(this.Tournament, ((Button)sender).DataContext as TournamentRound);
            trg.Show();
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Opens <see cref="RequestedByes"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewReqByes_OnClick(object sender, RoutedEventArgs e)
        {
            RequestedByes rb = new(this.Tournament, ((Button)sender).DataContext as TournamentRound);
            rb.Show();
            Window.GetWindow(this).Close();
        }
    }
}
