namespace EloCalculator.GUI
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewTournament.xaml.
    /// </summary>
    public partial class NewTournament : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTournament"/> class.
        /// </summary>
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
            this.Type.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a new <see cref="Tournament"/> to <see cref="TournamentDatabase.Tournaments"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.Name.Text == string.Empty)
            {
                MessageBox.Show("Name must not be empty.", "Exception!");
            }
            else
            {
                _ = new Tournament(this.Name.Text, (TournamentType)this.Type.SelectedIndex);
                Utility.UpdateAll();
                this.Close();
            }
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
