namespace EloCalculator.GUI
{
    using System.Collections.ObjectModel;
    using EloCalculator;

    public static class Utility
    {
        public static ObservableCollection<Game> Games = new();

        public static ObservableCollection<Player> Players = new();

        public static ObservableCollection<Tournament> Tournaments = new();

        public static ObservableCollection<TournamentPlayer> TournamentPlayers = new();

        public static ObservableCollection<TournamentRound> TournamentRounds = new();
        
        public static ObservableCollection<Game> TournamentRoundGames = new();

        public static void UpdateGames()
        {
            Games.Clear();
            foreach (Game g in GameDatabase.Games)
            {
                Games.Add(g);
            }
        }

        public static void UpdatePlayers()
        {
            Players.Clear();
            foreach (Player g in PlayerDatabase.Players)
            {
                Players.Add(g);
            }
        }

        public static void UpdateTournaments()
        {
            Tournaments.Clear();
            foreach (Tournament g in TournamentDatabase.Tournaments)
            {
                Tournaments.Add(g);
            }
        }

        public static void UpdateTournamentPlayers(Tournament tournament)
        {
            TournamentPlayers.Clear();
            foreach (TournamentPlayer player in tournament.Players)
            {
                TournamentPlayers.Add(player);
            }
        }

        public static void UpdateTournamentRounds(Tournament tournament)
        {
            TournamentRounds.Clear();
            foreach (TournamentRound round in tournament.Rounds)
            {
                TournamentRounds.Add(round);
            }
        }

        public static void UpdateTournamentRoundGames(TournamentRound round)
        {
            TournamentRoundGames.Clear();
            foreach (Game game in round.Games)
            {
                TournamentRoundGames.Add(game);
            }
        }
    }
}
