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
    public partial class TournamentRounds : Window
    {
        public Tournament Tournament { get; set; }

        public TournamentRounds(Tournament tournament)
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Tournament = tournament;
            this.DataGrid.ItemsSource = this.Tournament.Rounds;
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

        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {

        }

        public void ViewReqByes_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
