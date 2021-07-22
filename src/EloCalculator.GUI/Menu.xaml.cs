namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls;
    using EloCalculator;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Menu.xaml.
    /// </summary>
    public partial class Menu : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Loads <see cref="Game"/>s from a JSON file.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void LoadGame_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "JSON files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                GameDatabase.Games.Clear();
                GameDatabase.Load(fileDialog.FileName);
            }
        }

        /// <summary>
        /// Loads <see cref="Player"/>s from a JSON file.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void LoadPlayer_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "JSON files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                PlayerDatabase.Load(fileDialog.FileName);
            }
        }

        /// <summary>
        /// Loads <see cref="Tournament"/>s from a JSON file.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void LoadTournament_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "JSON files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                TournamentDatabase.Load(fileDialog.FileName);
            }
        }

        /// <summary>
        /// Opens <see cref="Games"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {
            Games games = new();
            games.Show();
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Opens <see cref="Players"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewPlayers_OnClick(object sender, RoutedEventArgs e)
        {
            Players players = new();
            players.Show();
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Opens <see cref="Tournaments"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void ViewTournaments_OnClick(object sender, RoutedEventArgs e)
        {
            Tournaments tournaments = new();
            tournaments.Show();
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Opens <see cref="NewGame"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddGame_OnClick(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new();
            newGame.Show();
        }

        /// <summary>
        /// Opens <see cref="NewPlayer"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddPlayer_OnClick(object sender, RoutedEventArgs e)
        {
            NewPlayer newPlayer = new();
            newPlayer.Show();
        }

        /// <summary>
        /// Opens <see cref="NewTournament"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddTournament_OnClick(object sender, RoutedEventArgs e)
        {
            NewTournament newTournament = new();
            newTournament.Show();
        }

        /// <summary>
        /// Opens <see cref="NewTournamentPlayer"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddTournamentPlayer_OnClick(object sender, RoutedEventArgs e)
        {
            NewTournamentPlayer newTournamentPlayer = new();
            newTournamentPlayer.Show();
        }

        /// <summary>
        /// Opens <see cref="NewTournamentRound"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddTournamentRound_OnClick(object sender, RoutedEventArgs e)
        {
            NewTournamentRound newTournamentRound = new();
            newTournamentRound.Show();
        }

        /// <summary>
        /// Opens <see cref="NewTournamentGame"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddTournamentGames_OnClick(object sender, RoutedEventArgs e)
        {
            NewTournamentGame newTournamentGames = new();
            newTournamentGames.Show();
        }

        /// <summary>
        /// Opens <see cref="NewRequestedBye"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void AddRequestedBye_OnClick(object sender, RoutedEventArgs e)
        {
            NewRequestedBye newRequestedBye = new();
            newRequestedBye.Show();
        }
    }
}
