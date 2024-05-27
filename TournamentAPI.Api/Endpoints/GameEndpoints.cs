using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Interfaces;

namespace TournamentAPI.Endpoints;

public static class GameEndpoints {
    public static void MapGameEndpoints(this WebApplication app) {
        app.MapGet("/games", async (
            IGameService service
        ) => {
            var list = await service.GetAllGamesAsync();

            return Results.Ok(list);
        });


        app.MapGet("/games/{id}", async (
            int id,
            IGameService service
        ) => {
            var result = await service.GetGameByIdAsync(id);

            return result.Match(
                g => Results.Ok(g),
                n => Results.NotFound($"Could not find game with id {id}")
            );
        });


        app.MapPost("/games", async (
            IGameService service,
            CreateGameDto dto
        ) => {
            var result = await service.CreateGameAsync(dto);

            return result.Match(
                g => Results.Created($"/games/{g.GameId}", g),
                n => Results.NotFound("Could not find the created game")
            ); 
            
            // return Results.Created($"/games/{added.GameId}", added);
        });


        app.MapPut("/games/{id}", async (
            int id,
            UpdateGameDto dto,
            IGameService service
        ) => {
            var result = await service.UpdateGameAsync(dto, id);

            return result.Match(
                g => Results.Ok(g),
                n => Results.NotFound($"Could not find game with id {id}")
            );
        });


        app.MapDelete("/games/{id}", async (
            int id,
            IGameService service
        ) => {
            var result = await service.RemoveGameAsync(id);

            return result.Match(
                s => Results.NoContent(),
                n => Results.NotFound($"Could not find game with id {id}")
            );
        });
    }
}