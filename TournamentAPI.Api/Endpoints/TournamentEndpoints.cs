using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Interfaces;

namespace TournamentAPI.Endpoints;

public static class TournamentEndpoints {
    public static void MapTournamentEndpoints(this WebApplication app) {
        app.MapGet("/tournaments", async (
            ITournamentService service
        ) => {
            var list = await service.GetAllTournamentsAsync();

            return Results.Ok(list); 
        });


        app.MapGet("/tournaments/{id}", async (
            int id, 
            ITournamentService service
        ) => {
            var result = await service.GetTournamentByIdAsync(id);

            return result.Match(
                t => Results.Ok(t),
                n => Results.NotFound($"Could not find tournament with id {id}")
            ); 
        });
        

        app.MapPost("/tournaments", async (
            ITournamentService service, 
            CreateTournamentDto dto
        ) => {
            var added = await service.CreateTournamentAsync(dto);

            return Results.Created($"/tournaments/{added.TournamentId}", added); 
        });


        app.MapPut("/tournaments/{id}", async (
            int id,
            UpdateTournamentDto dto,
            ITournamentService service
        ) => {
            var result = await service.UpdateTournamentAsync(dto, id);

            return result.Match(
                t => Results.Ok(t),
                n => Results.NotFound($"Could not find tournament with id {id}")
            ); 
        });


        app.MapDelete("/tournaments/{id}", async (
            int id,
            ITournamentService service
        ) => {
            var result = await service.RemoveTournamentAsync(id);

            return result.Match(
                t => Results.Ok(t),
                n => Results.NotFound($"Could not find tournament with id {id}")
            ); 
        });
    }
}