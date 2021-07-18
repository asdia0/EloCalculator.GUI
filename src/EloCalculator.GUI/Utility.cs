namespace EloCalculator.GUI
{
    using System.Collections.ObjectModel;
    using EloCalculator;

    public static class Utility
    {
        public static ObservableCollection<Game> Games = new();

        public static void UpdateGames()
        {
            Games.Clear();
            foreach (Game g in GameDatabase.Games)
            {
                Games.Add(g);
            }
        }
    }
}
