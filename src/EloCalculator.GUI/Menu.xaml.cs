namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using EloCalculator;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Menu.xaml.
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            this.InitializeComponent();
        }

        public void LoadGame_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "JSON files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                GameDatabase.Load(fileDialog.FileName);
            }
        }

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

        public void ViewGames_OnClick(object sender, RoutedEventArgs e)
        {
            Games games = new();
            Window.GetWindow(this).Close();
            games.Show();
        }

        public void ViewPlayers_OnClick(object sender, RoutedEventArgs e)
        {
            Players players = new();
            Window.GetWindow(this).Close();
            players.Show();
        }

        public void ViewTournaments_OnClick(object sender, RoutedEventArgs e)
        {
            Tournaments tournaments = new();
            Window.GetWindow(this).Close();
            tournaments.Show();
        }
    }
}
