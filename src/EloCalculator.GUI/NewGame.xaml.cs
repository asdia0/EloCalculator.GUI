namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewGame.xaml.
    /// </summary>
    public partial class NewGame : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewGame"/> class.
        /// </summary>
        public NewGame()
        {
            this.InitializeComponent();
            this.White.ItemsSource = PlayerDatabase.Players.Select(i => $"{i.ID} ({i.Name})");
            this.Black.ItemsSource = PlayerDatabase.Players.Select(i => $"{i.ID} ({i.Name})");
            this.Result.ItemsSource = new List<string>()
            {
                "White",
                "Black",
                "Draw",
            };
        }

        /// <summary>
        /// Adds a new <see cref="Game"/> to <see cref="GameDatabase.Games"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.White.SelectedIndex == this.Black.SelectedIndex)
            {
                MessageBox.Show("Players cannot be the same.", "Exception!");
            }
            else
            {
                _ = new Game(PlayerDatabase.Players[this.White.SelectedIndex], PlayerDatabase.Players[this.Black.SelectedIndex], (Result)int.Parse(this.Result.SelectedIndex.ToString()), DateTime.Now, (bool)this.Rated.IsChecked);
                this.Close();
            }
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
