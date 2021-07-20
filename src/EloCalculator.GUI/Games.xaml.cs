namespace EloCalculator.GUI
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for Games.xaml.
    /// </summary>
    public partial class Games : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Games"/> class.
        /// </summary>
        public Games()
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            _ = new Game(new("Player 1"), new("Player 2"), Result.White, DateTime.Now, true);
            this.DataGrid.ItemsSource = Utility.Games;
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
