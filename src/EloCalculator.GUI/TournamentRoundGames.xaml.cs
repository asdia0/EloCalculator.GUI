namespace EloCalculator.GUI
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interaction logic for Games.xaml.
    /// </summary>
    public partial class TournamentRoundGames : Window
    {
        public TournamentRound TournamentRound { get; set; }

        public TournamentRoundGames(TournamentRound round)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.TournamentRound = round;
            Utility.UpdateTournamentRoundGames(this.TournamentRound);
            this.DataGrid.ItemsSource = Utility.TournamentRoundGames;
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
        }
    }
}
