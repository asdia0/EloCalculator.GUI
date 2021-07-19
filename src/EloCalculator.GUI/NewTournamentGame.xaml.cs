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
    public partial class NewTournamentGame : Window
    {
        private Tournament? _Tournament
        {
            get
            {
                try
                {
                    return Utility.Tournaments[this.Tournament.SelectedIndex];
                }
                catch
                {
                    return null;
                }
            }
        }

        public NewTournamentGame()
        {
            this.InitializeComponent();
            Utility.UpdateGames();
            Utility.UpdateTournaments();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Tournament.SelectedIndex = 0;
            this.Round.ItemsSource = this._Tournament == null ? new() : this._Tournament.Rounds;
            this.Game.ItemsSource = Utility.Games.Select(i => $"{i.ID} ({i.WhitePlayer.Name}-{i.BlackPlayer.Name}, {i.Result}, {i.DateTime})");
        }

        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentRound r = this._Tournament.Rounds[this.Round.SelectedIndex];
            r.AddGame(Utility.Games[this.Game.SelectedIndex]);
            Utility.UpdateTournaments();
            Utility.UpdateTournamentRounds(this._Tournament);
            Utility.UpdateTournamentRoundGames(r);
            this.Close();
        }

        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
