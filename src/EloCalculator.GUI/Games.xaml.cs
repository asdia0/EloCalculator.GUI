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
    using System.Windows.Shapes;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interaction logic for Games.xaml.
    /// </summary>
    public partial class Games : Window
    {
        public Games()
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            Game add = new(new("Player 1"), new("Player 2"), Result.White, DateTime.Now, true);

            Utility.UpdateGames();
            this.DataGrid.ItemsSource = Utility.Games;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        public void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            // Delete game

            // Update player stats

            // Update tournament stats

            Utility.UpdateGames();
            Utility.UpdatePlayers();
            Utility.UpdateTournaments();
        }
    }
}
