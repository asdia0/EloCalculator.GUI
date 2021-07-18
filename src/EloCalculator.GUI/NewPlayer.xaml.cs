namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewPlayer.xaml
    /// </summary>
    public partial class NewPlayer : Window
    {
        public NewPlayer()
        {
            this.InitializeComponent();
        }

        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            Player p = new(this.Name.Text);
            Utility.UpdateGames();
            Utility.UpdatePlayers();
            this.Close();
        }

        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
