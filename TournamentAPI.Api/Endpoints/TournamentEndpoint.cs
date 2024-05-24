using Microsoft.AspNetCore.Mvc;
using TournamentAPI.Data.Repositories;
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
                n => Results.NotFound($"Could not find id {id}")
            );

        });
        
        
        
    }
}

