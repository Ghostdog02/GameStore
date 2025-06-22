using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient(HttpClient httpClient)
{
    private readonly Genre[] genres =
    {
        new Genre { Id = 1, Name = "Action" },
        new Genre { Id = 2, Name = "Adventure" },
        new Genre { Id = 3, Name = "RPG" },
        new Genre { Id = 4, Name = "Simulation" },
        new Genre { Id = 5, Name = "Strategy" },
        new Genre { Id = 6, Name = "Sports" },
        new Genre { Id = 7, Name = "Puzzle" },
        new Genre { Id = 8, Name = "Fighting" },
        new Genre { Id = 9, Name = "Shooter" },
        new Genre { Id = 10, Name = "Horror" },
        new Genre { Id = 11, Name = "Platformer" },
        new Genre { Id = 12, Name = "Racing" },
        new Genre { Id = 13, Name = "MMORPG" },
        new Genre { Id = 14, Name = "Open World" },
        new Genre { Id = 15, Name = "Stealth" },
        new Genre { Id = 16, Name = "Card" },
        new Genre { Id = 17, Name = "Idle" },
        new Genre { Id = 18, Name = "Battle Royale" }
    };

    public Genre[] GetGenres()
    {
        return genres;
    }
}
