namespace EloCalculator.GUI
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using EloCalculator;

    /// <summary>
    /// This class contains useful methods.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Gets <see cref="GameDatabase.Games"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static ObservableCollection<Game> Games
        {
            get
            {
                ObservableCollection<Game> games = new();

                foreach (Game game in GameDatabase.Games)
                {
                    games.Add(game);
                }

                return games;
            }
        }

        /// <summary>
        /// Gets <see cref="PlayerDatabase.Players"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static ObservableCollection<Player> Players
        {
            get
            {
                ObservableCollection<Player> players = new();

                foreach (Player player in PlayerDatabase.Players)
                {
                    players.Add(player);
                }

                return players;
            }
        }

        /// <summary>
        /// Gets <see cref="TournamentDatabase.Tournaments"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static ObservableCollection<Tournament> Tournaments
        {
            get
            {
                ObservableCollection<Tournament> tournaments = new();

                foreach (Tournament tournament in TournamentDatabase.Tournaments)
                {
                    tournaments.Add(tournament);
                }

                return tournaments;
            }
        }

        /// <summary>
        /// Gets <see cref="TournamentPlayer"/>s as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, ObservableCollection<TournamentPlayer>> TournamentPlayers
        {
            get
            {
                Dictionary<Tournament, ObservableCollection<TournamentPlayer>> tournamentPlayers = new();

                foreach (Tournament tournament in TournamentDatabase.Tournaments)
                {
                    ObservableCollection<TournamentPlayer> players = new();

                    foreach (TournamentPlayer player in tournament.Players)
                    {
                        players.Add(player);
                    }

                    tournamentPlayers.Add(tournament, players);
                }

                return tournamentPlayers;
            }
        }

        /// <summary>
        /// Gets <see cref="TournamentRound"/>s as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, ObservableCollection<TournamentRound>> TournamentRounds
        {
            get
            {
                Dictionary<Tournament, ObservableCollection<TournamentRound>> tournamentRounds = new();

                foreach (Tournament tournament in TournamentDatabase.Tournaments)
                {
                    ObservableCollection<TournamentRound> rounds = new();

                    foreach (TournamentRound round in tournament.Rounds)
                    {
                        rounds.Add(round);
                    }

                    tournamentRounds.Add(tournament, rounds);
                }

                return tournamentRounds;
            }
        }

        /// <summary>
        /// Gets <see cref="TournamentRound.Games"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, Dictionary<TournamentRound, ObservableCollection<Game>>> TournamentRoundGames
        {
            get
            {
                Dictionary<Tournament, Dictionary<TournamentRound, ObservableCollection<Game>>> tournamentRoundGames = new();

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

                    tournamentRoundGames.Add(tournament, rounds);
                }

                return tournamentRoundGames;
            }
        }

        /// <summary>
        /// Gets <see cref="TournamentPlayer.Games"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, Dictionary<TournamentPlayer, ObservableCollection<Game>>> TournamentPlayerGames
        {
            get
            {
                Dictionary<Tournament, Dictionary<TournamentPlayer, ObservableCollection<Game>>> tournamentPlayerGames = new();

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

                    tournamentPlayerGames.Add(tournament, rounds);
                }

                return tournamentPlayerGames;
            }
        }

        /// <summary>
        /// Gets <see cref="TournamentRound.RequestedByes"/> as an <see cref="ObservableCollection{T}"/>.
        /// </summary>
        public static Dictionary<Tournament, Dictionary<TournamentRound, ObservableCollection<TournamentPlayer>>> TournamentRoundRequestedByes
        {
            get
            {
                Dictionary<Tournament, Dictionary<TournamentRound, ObservableCollection<TournamentPlayer>>> tournamentRoundGames = new();

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

                    tournamentRoundGames.Add(tournament, rounds);
                }

                return tournamentRoundGames;
            }
        }

        /// <summary>
        /// Creates a <see cref="Popup"/> displaying a message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <returns>A <see cref="Popup"/> displaying a message.</returns>
        public static Popup CreatePopup(string message)
        {
            Popup popup = new Popup();
            TextBlock popupText = new TextBlock();
            popupText.Text = message;
            popup.Child = popupText;
            return popup;
        }
    }
}
