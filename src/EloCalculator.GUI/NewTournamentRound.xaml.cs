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
    public partial class NewTournamentRound : Window
    {
        public NewTournamentRound()
        {
            this.InitializeComponent();
            Utility.UpdatePlayers();
            Utility.UpdateTournaments();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
        }

        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentRound r = new(Utility.Tournaments[this.Tournament.SelectedIndex]);
            Utility.UpdateTournaments();
            Utility.UpdateTournamentRounds(Utility.Tournaments[this.Tournament.SelectedIndex]);
            this.Close();
        }

        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
