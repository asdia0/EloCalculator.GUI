namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        public NewGame()
        {
            this.InitializeComponent();
            this.WhiteID.ItemsSource = PlayerDatabase.Players.Select(i => $"{i.ID} ({i.Name})");
            this.BlackID.ItemsSource = PlayerDatabase.Players.Select(i => $"{i.ID} ({i.Name})");
            this.Result.ItemsSource = new List<string>()
            {
                "White",
                "Black",
                "Draw",
            };
        }

        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WhiteID.SelectedIndex == this.BlackID.SelectedIndex)
            {
                // create new window
            }
            else
            {
                Game g = new Game(PlayerDatabase.Players[this.WhiteID.SelectedIndex], PlayerDatabase.Players[this.BlackID.SelectedIndex], (Result)int.Parse(this.Result.SelectedIndex.ToString()), DateTime.Now, (bool)this.Rated.IsChecked);
                Utility.UpdateGames();
                Utility.UpdatePlayers();
            }
            this.Close();
        }

        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
