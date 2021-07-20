namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for Games.xaml.
    /// </summary>
    public partial class Tournaments : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tournaments"/> class.
        /// </summary>
        public Tournaments()
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.DataGrid.ItemsSource = Utility.Tournaments;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        /// <summary>
        /// Delete <see cref="Tournament"/>s when the DEL key is pressed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Key == Key.Delete)
            {
                foreach (Tournament tournament in grid.SelectedItems)
                {
                    TournamentDatabase.Tournaments.Remove(tournament);
                }
            }

            // TODO: Reload databases.
        }

        /// <summary>
        /// Opens <see cref="TournamentPlayers"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewPlayers_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentPlayers tp = new(((Button)sender).DataContext as Tournament);
            tp.Show();
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Opens <see cref="TournamentRounds"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewRounds_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentRounds tp = new(((Button)sender).DataContext as Tournament);
            tp.Show();
            Window.GetWindow(this).Close();
        }
    }
}
