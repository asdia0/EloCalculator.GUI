namespace EloCalculator.GUI
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewRequestedBye.xaml.
    /// </summary>
    public partial class NewRequestedBye : Window
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
        /// Initializes a new instance of the <see cref="NewRequestedBye"/> class.
        /// </summary>
        public NewRequestedBye()
        {
            this.InitializeComponent();
            Utility.UpdateAll();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Tournament.SelectedIndex = 0;
            this.Round.ItemsSource = this._Tournament == null ? new List<string>() : this._Tournament.Rounds.Select(i => $"Round {i.ID}");
            this.Round.SelectedIndex = 0;
            this.Player.ItemsSource = this._Tournament.Players.Select(i => $"{i.ID} ({i.Player.Name})");
            this.Player.SelectedIndex = 0;
        }

        public void Tournament_OnChange(object sender, RoutedEventArgs e)
        {
            this.Round.ItemsSource = this._Tournament == null ? new List<string>() : this._Tournament.Rounds.Select(i => $"Round {i.ID}");
            this.Round.SelectedIndex = 0;
            this.Player.ItemsSource = this._Tournament.Players.Select(i => $"{i.ID} ({i.Player.Name})");
            this.Player.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a <see cref="TournamentPlayer"/> to a <see cref="EloCalculator.TournamentRound.RequestedByes"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentPlayer tPlayer = this._Tournament.Players[this.Player.SelectedIndex];
            TournamentRound round = this._Tournament.Rounds[this.Round.SelectedIndex];

            if (round.RequestedByes.Contains(tPlayer))
            {
                MessageBox.Show($"Tournament player {tPlayer.ID} has already requested a bye.", "Exception!");
            }
            else if (round.PairingBye == tPlayer)
            {
                MessageBox.Show($"Tournament player {tPlayer.ID} has already received a pairing bye.", "Exception!");
            }
            else
            {
                round.RequestedByes.Add(tPlayer);
                Utility.UpdateAll();
                Utility.RefreshWindows();
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
