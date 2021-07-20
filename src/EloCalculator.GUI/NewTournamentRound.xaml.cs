namespace EloCalculator.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewTournamentRound.xaml.
    /// </summary>
    public partial class NewTournamentRound : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTournamentRound"/> class.
        /// </summary>
        public NewTournamentRound()
        {
            this.InitializeComponent();
            this.Tournament.ItemsSource = Utility.Tournaments.Select(i => $"{i.ID} ({i.Name})");
            this.Tournament.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a <see cref="TournamentRound"/> to a <see cref="EloCalculator.Tournament"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            _ = new TournamentRound(Utility.Tournaments[this.Tournament.SelectedIndex]);
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
