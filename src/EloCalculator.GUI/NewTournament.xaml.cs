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
    public partial class NewTournament : Window
    {
        public NewTournament()
        {
            this.InitializeComponent();
            this.Type.ItemsSource = new List<string>()
            {
                "Arena",
                "Danish",
                "Dutch",
                "Monrad",
                "RoundRobin",
            };
        }

        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            Tournament t = new(this.Name.Text, (TournamentType)this.Type.SelectedIndex);
            Utility.UpdateTournaments();
            this.Close();
        }

        public void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
