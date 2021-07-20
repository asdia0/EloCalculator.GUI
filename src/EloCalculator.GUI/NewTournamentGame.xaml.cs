namespace EloCalculator.GUI
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewTournamentGame.xaml.
    /// </summary>
    public partial class NewTournamentGame : Window
    {
        /// <summary>
        /// Gets the <see cref="Tournament"/> the <see cref="Game"/> is being added to.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="NewTournamentGame"/> class.
        /// </summary>
        public NewTournamentGame()
        {
            this.InitializeComponent();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Round.ItemsSource = this._Tournament == null ? new() : this._Tournament.Rounds;
            this.Game.ItemsSource = Utility.Games.Select(i => $"{i.ID} ({i.WhitePlayer.Name}-{i.BlackPlayer.Name}, {i.Result}, {i.DateTime})");
            this.Tournament.SelectedIndex = 0;
            this.Round.SelectedIndex = 0;
            this.Game.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a <see cref="EloCalculator.Game"/> to a <see cref="TournamentRound"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            List<Game> tournamentGames = new();
            foreach (TournamentRound round in Utility.TournamentRoundGames[this._Tournament].Keys)
            {
                tournamentGames.AddRange(Utility.TournamentRoundGames[this._Tournament][round]);
            }

            Game game = Utility.Games[this.Game.SelectedIndex];

            if (tournamentGames.Contains(game))
            {
                MessageBox.Show($"Game {game.ID} has already been added to Tournament {this._Tournament.ID} ({this._Tournament.Name})", "Exception!");
            }
            else
            {
                this._Tournament.Rounds[this.Round.SelectedIndex].AddGame(Utility.Games[this.Game.SelectedIndex]);
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
