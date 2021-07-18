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

    /// <summary>
    /// Interaction logic for Players.xaml.
    /// </summary>
    public partial class Players : Window
    {
        public Players()
        {
            this.InitializeComponent();
            this.WindowState = WindowState.Maximized;
            Utility.UpdatePlayers();
            this.DataGrid.ItemsSource = Utility.Players;
            this.DataGrid.IsSynchronizedWithCurrentItem = true;
        }

        public void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            // Delete player

            // Update game stats

            // Update tournament stats

            Utility.UpdateGames();
            Utility.UpdatePlayers();
            Utility.UpdateTournaments();
        }
    }
}
