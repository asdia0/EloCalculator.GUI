namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for Players.xaml.
    /// </summary>
    public partial class Players : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Players"/> class.
        /// </summary>
        public Players()
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.DataGrid.ItemsSource = Utility.Players;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        /// <summary>
        /// Delete <see cref="Player"/>s when the DEL key is pressed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Key == Key.Delete)
            {
                foreach (Player player in grid.SelectedItems)
                {
                    // Remove games the player played.
                    GameDatabase.Games.RemoveAll(i => i.WhitePlayer == player || i.BlackPlayer == player);

                    // Remove player from the database.
                    PlayerDatabase.Players.Remove(player);
                }
            }

            // TODO: Reload databases.
        }

        /// <summary>
        /// Opens <see cref="PlayerGames"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {
            PlayerGames pg = new(((Button)sender).DataContext as Player);
            pg.Show();
            Window.GetWindow(this).Close();
        }
    }
}
