namespace EloCalculator.GUI
{
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for PlayerGames.xaml.
    /// </summary>
    public partial class PlayerGames : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerGames"/> class.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to display.</param>
        public PlayerGames(Player player)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            Utility.UpdateAll();
            this.DataGrid.ItemsSource = Utility.Games.Where(i => i.WhitePlayer == player || i.BlackPlayer == player);
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

            Utility.UpdateAll();
        }
    }
}
