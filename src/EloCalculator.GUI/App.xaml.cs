namespace EloCalculator.GUI
{
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_OnExit(object sender, ExitEventArgs e)
        {
            GameDatabase.Export("EloCalculator.GUI/Games.json");
            PlayerDatabase.Export("EloCalculator.GUI/Players.json");
            TournamentDatabase.Export("EloCalculator.GUI/Tournaments.json");
        }
    }
}
