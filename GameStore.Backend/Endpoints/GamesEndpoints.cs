using System;
using GameStore.Backend.Data;
using GameStore.Backend.Dtos;
using GameStore.Backend.Entities;
using GameStore.Backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Backend.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameSummaryDto> games = [
        new (1, "Street Fighter V", "Fighting",
            19.99m, new DateOnly(1992, 7, 15)),

        new (2, "Final Fantasy XIV", "Roleplaying",
            59.99m, new DateOnly(2010, 9, 30)),

        new (3, "Fifa 23",
        "Sports", 69.99m, new DateOnly(2022, 9, 27))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");

        //GET /games
        group.MapGet("/", (GameStoreContext dbContext) =>
            dbContext.Games
                     .Include(game => game.Genre)
                     .Select(game => game.ToGameSummaryDto())
                     .AsNoTracking());

        //GET /games/1
        group.MapGet("/{id:int}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);

            return game is null ? Results.NotFound() :
                Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        //POST /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName,
                            new { id = game.Id },
                            game.ToGameDetailsDto());
        })
        .WithParameterValidation();

        //PUT /games/1
        group.MapPut("/{id:int}", (int id, UpdateGameDto updatedGameDto, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGameDto.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        })
        .WithParameterValidation();

        //DELETE /games/1
        group.MapDelete("/{id:int}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
