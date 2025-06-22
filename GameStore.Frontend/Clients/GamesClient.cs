using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    private readonly List<GameSummary> games =
    [
        new GameSummary
        {
            Id = 1,
            Name = "Street Fighter V",
            Genre = "Fighting",
            Price = 29.99m,
            ReleaseDate = new DateOnly(2016, 2, 16)
        },

        new GameSummary
        {
            Id = 2,
            Name = "The Witcher 3: Wild Hunt",
            Genre = "RPG",
            Price = 39.99m,
            ReleaseDate = new DateOnly(2015, 5, 19)
        },

        new GameSummary
        {
            Id = 3,
            Name = "DOOM Eternal",
            Genre = "Shooter",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2020, 3, 20)
        }
    ];

    private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();

    public GameSummary[] GetGames() => games.ToArray();

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var GameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(GameSummary);
    }

    private Genre GetGenreById(string? genreId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(genreId);

        var genre = genres.Single(genre => genre.Id == int.Parse(genreId));
        return genre;
    }

    public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = genres.Single(tempGenre => string.Equals(
            tempGenre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game, $"Game with ID {id} not found.");
        return game;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }
}
