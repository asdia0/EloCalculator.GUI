namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Players.xaml.
    /// </summary>
    public partial class TournamentPlayers : Window
    {
        private Tournament Tournament;

        private ObservableCollection<TournamentPlayer> Players { get; set; }

        public TournamentPlayers(Tournament tournament)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            Utility.UpdateTournaments();
            Utility.UpdateTournamentPlayers(this.Tournament);
            this.Players = Utility.TournamentPlayers;
            this.DataGrid.ItemsSource = this.Players;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

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

            // Update player stats

            // Update tournament stats

            Utility.UpdateGames();
            Utility.UpdatePlayers();
            Utility.UpdateTournaments();
            Utility.UpdateTournamentPlayers(this.Tournament);
        }

        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {
            TournamentPlayerGames tpg = new(this.Tournament, ((Button)sender).DataContext as TournamentPlayer);
            tpg.Show();
        }
    }
}
