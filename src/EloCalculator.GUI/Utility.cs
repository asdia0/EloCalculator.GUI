namespace EloCalculator.GUI
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using EloCalculator;

    /// <summary>
    /// This class contains useful methods.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Gets <see cref="GameDatabase.Games"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static ObservableCollection<Game> Games = new();

        /// <summary>
        /// Gets <see cref="PlayerDatabase.Players"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static ObservableCollection<Player> Players = new();

        /// <summary>
        /// Gets <see cref="TournamentDatabase.Tournaments"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static ObservableCollection<Tournament> Tournaments = new();

        /// <summary>
        /// Gets <see cref="TournamentPlayer"/>s as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, ObservableCollection<TournamentPlayer>> TournamentPlayers = new();

        /// <summary>
        /// Gets <see cref="TournamentRound"/>s as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, ObservableCollection<TournamentRound>> TournamentRounds = new();

        /// <summary>
        /// Gets <see cref="TournamentRound.Games"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, Dictionary<TournamentRound, ObservableCollection<Game>>> TournamentRoundGames = new();

        /// <summary>
        /// Gets <see cref="TournamentPlayer.Games"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, Dictionary<TournamentPlayer, ObservableCollection<Game>>> TournamentPlayerGames = new();

        /// <summary>
        /// Gets <see cref="TournamentRound.RequestedByes"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, Dictionary<TournamentRound, ObservableCollection<TournamentPlayer>>> TournamentRoundRequestedByes = new();

        /// <summary>
        /// Updates <see cref="Games"/>.
        /// </summary>
        public static void UpdateGames()
        {
            Games.Clear();

            foreach (Game game in GameDatabase.Games)
            {
                Games.Add(game);
            }
        }

        /// <summary>
        /// Updates <see cref="Players"/>.
        /// </summary>
        public static void UpdatePlayers()
        {
            Players.Clear();

            foreach (Player player in PlayerDatabase.Players)
            {
                Players.Add(player);
            }
        }

        /// <summary>
        /// Updates <see cref="Tournaments"/>.
        /// </summary>
        public static void UpdateTournaments()
        {
            Tournaments.Clear();

            foreach (Tournament tournament in TournamentDatabase.Tournaments)
            {
                Tournaments.Add(tournament);
            }
        }

        /// <summary>
        /// Updates <see cref="TournamentPlayers"/>.
        /// </summary>
        public static void UpdateTournamentPlayers()
        {
            TournamentPlayers.Clear();

            foreach (Tournament tournament in TournamentDatabase.Tournaments)
            {
                ObservableCollection<TournamentPlayer> players = new();

                foreach (TournamentPlayer player in tournament.Players)
                {
                    players.Add(player);
                }

                TournamentPlayers.Add(tournament, players);
            }
        }

        /// <summary>
        /// Updates <see cref="TournamentRounds"/>.
        /// </summary>
        public static void UpdateTournamentRounds()
        {
            TournamentRounds.Clear();

            foreach (Tournament tournament in TournamentDatabase.Tournaments)
            {
                ObservableCollection<TournamentRound> rounds = new();

                foreach (TournamentRound round in tournament.Rounds)
                {
                    rounds.Add(round);
                }

                TournamentRounds.Add(tournament, rounds);
            }
        }

        /// <summary>
        /// Updates <see cref="TournamentRoundGames"/>.
        /// </summary>
        public static void UpdateTournamentRoundGames()
        {
            TournamentRoundGames.Clear();

            foreach (Tournament tournament in TournamentDatabase.Tournaments)
            {
                Dictionary<TournamentRound, ObservableCollection<Game>> rounds = new();

                foreach (TournamentRound round in tournament.Rounds)
                {
                    ObservableCollection<Game> games = new();

                    foreach (Game game in round.Games)
                    {
                        games.Add(game);
                    }

                    rounds.Add(round, games);
                }

                TournamentRoundGames.Add(tournament, rounds);
            }
        }

        /// <summary>
        /// Updates <see cref="TournamentPlayerGames"/>.
        /// </summary>
        public static void UpdateTournamentPlayerGames()
        {
            TournamentPlayerGames.Clear();

            foreach (Tournament tournament in TournamentDatabase.Tournaments)
            {
                Dictionary<TournamentPlayer, ObservableCollection<Game>> rounds = new();

                foreach (TournamentPlayer player in tournament.Players)
                {
                    ObservableCollection<Game> games = new();

                    foreach (Game game in player.Games)
                    {
                        games.Add(game);
                    }

                    rounds.Add(player, games);
                }

                TournamentPlayerGames.Add(tournament, rounds);
            }
        }

        /// <summary>
        /// Updates <see cref="TournamentRoundRequestedByes"/>.
        /// </summary>
        public static void UpdateTournamentRoundRequestedByes()
        {
            TournamentRoundRequestedByes.Clear();

            foreach (Tournament tournament in TournamentDatabase.Tournaments)
            {
                Dictionary<TournamentRound, ObservableCollection<TournamentPlayer>> rounds = new();

                foreach (TournamentRound round in tournament.Rounds)
                {
                    ObservableCollection<TournamentPlayer> players = new();

                    foreach (TournamentPlayer player in round.RequestedByes)
                    {
                        players.Add(player);
                    }

                    rounds.Add(round, players);
                }

                TournamentRoundRequestedByes.Add(tournament, rounds);
            }
        }

        /// <summary>
        /// Updates all properties.
        /// </summary>
        public static void UpdateAll()
        {
            UpdateGames();
            UpdatePlayers();
            UpdateTournamentPlayerGames();
            UpdateTournamentPlayers();
            UpdateTournamentRoundGames();
            UpdateTournamentRoundRequestedByes();
            UpdateTournamentRounds();
            UpdateTournaments();
        }
    }
}
