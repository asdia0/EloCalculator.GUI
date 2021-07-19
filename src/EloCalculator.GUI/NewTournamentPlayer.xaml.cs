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
    public partial class NewTournamentPlayer : Window
    {
        public NewTournamentPlayer()
        {
            this.InitializeComponent();
            Utility.UpdatePlayers();
            Utility.UpdateTournaments();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Player.ItemsSource = Utility.Players.Select(i => $"{i.ID} ({i.Name})");
        }

        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentPlayer tp = new(Utility.Tournaments[this.Tournament.SelectedIndex], Utility.Players[this.Player.SelectedIndex]);
            Utility.UpdateTournaments();
            Utility.UpdateTournamentPlayers(Utility.Tournaments[this.Tournament.SelectedIndex]);
            this.Close();
        }

        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
