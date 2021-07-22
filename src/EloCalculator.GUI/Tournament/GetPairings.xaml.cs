namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for GetPairings.xaml.
    /// </summary>
    public partial class GetPairings : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPairings"/> class.
        /// </summary>
        public GetPairings()
        {
            this.InitializeComponent();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Tournament.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets the pairings for the next tournament round.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Get_OnClick(object sender, RoutedEventArgs e)
        {
            Tournament t = Utility.Tournaments[this.Tournament.SelectedIndex];
            MessageBox.Show(string.Join("\n", t.GetPairings().Select(i => $"{i.White.ID} ({i.White.Player.Name}) - {i.Black.ID} ({i.Black.Player.Name})")), $"Pairings for Round {t.Rounds.Last().ID + 1} of {t.Name}");
            this.Close();
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
