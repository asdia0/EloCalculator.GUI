namespace EloCalculator.GUI
{
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for NewPlayer.xaml.
    /// </summary>
    public partial class NewPlayer : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewPlayer"/> class.
        /// </summary>
        public NewPlayer()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Adds a <see cref="Player"/> to <see cref="PlayerDatabase.Players"/>.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        public void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.Name.Text == string.Empty)
            {
                Popup popup = Utility.CreatePopup("Name must not be empty.");
                popup.IsOpen = true;
            }
            else
            {
                _ = new Player(this.Name.Text);
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
