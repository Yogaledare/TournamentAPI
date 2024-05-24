using Microsoft.AspNetCore.Mvc;
using TournamentAPI.Data.Repositories;
using TournamentAPI.Dto;
using TournamentAPI.Mappers;


namespace TournamentAPI.Endpoints;

public static class TournamentEndpoint {
    public static void MapTournamentEndpoints(this WebApplication app) {
        app.MapGet("/tournaments", async (
            IUoW uoW,
            ITournamentApiMapper mapper
        ) => {
            var list = await uoW.TournamentRepository.GetAllAsync();
            var output = list.Select(t => mapper.Tournament_TournamentDto(t));

            return output;
        });


        app.MapGet("/tournaments/{id}", async (
            int id,
            IUoW uoW,
            ITournamentApiMapper mapper
        ) => {
            var result = await uoW.TournamentRepository.GetAsync(id);

            return result.Match(
                t => Results.Ok(mapper.Tournament_TournamentDto(t)),
                n => Results.NotFound($"Could not find tournament with id {id}")
            );
        });

        app.MapPost("/tournaments", async (
            CreateTournamentDto dto,
            IUoW uow,
            ITournamentApiMapper mapper
        ) => {
            var tournament = mapper.CreateTournamentDto_Tournament(dto);
            await uow.TournamentRepository.Add(tournament);
            await uow.CompleteAsync();
            
            return Results.Created($"/tournaments/{tournament.TournamentId}", mapper.Tournament_TournamentDto(tournament));
        });


        app.MapPut("/tournaments/{id}", async (
            int id,
            CreateTournamentDto dto,
            IUoW uow,
            ITournamentApiMapper mapper
        ) => {
            var tournament = mapper.CreateTournamentDto_Tournament(dto, id);
            tournament.TournamentId = id;
            var result = await uow.TournamentRepository.Update(tournament);
            await uow.CompleteAsync();
            
            return result.Match(
                t => Results.Ok(mapper.Tournament_TournamentDto(t)),
                n => Results.NotFound($"Could not find tournament with id {id}")
            );
        });


        app.MapDelete("/tournaments/{id}", async (
            int id,
            IUoW uow
        ) => {
            var result = await uow.TournamentRepository.Remove(id);
            await uow.CompleteAsync();
            
            return result.Match(
                t => Results.Ok($"Tournament with id {id} deleted."),
                n => Results.NotFound($"Could not find tournament with id {id}")
            );
        });
    }
}