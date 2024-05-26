using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Entities;
using TournamentAPI.Core.Interfaces;

namespace TournamentAPI.Core.Mappers;

public class TournamentApiMapper : ITournamentApiMapper {
    public TournamentDto Tournament_TournamentDto(Tournament tournament) {
        return new TournamentDto(tournament.TournamentId, tournament.Title, tournament.StartDate);
    }


    public GameDto Game_GameDto(Game game) {
        return new GameDto(game.GameId, game.Title, game.StartDate, game.TournamentId, game.Tournament.Title);
    }


    public Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto) {
        return new Tournament {
            Title = dto.Title,
            StartDate = dto.StartDate,
        };
    }

    public Tournament UpdateTournamentDto_Tournament(UpdateTournamentDto dto, int id) {
        return new Tournament {
            TournamentId = id,
            Title = dto.Title,
            StartDate = dto.StartDate,
        };
    }


    public Game CreateGameDto_Game(CreateGameDto dto) {
        return new Game {
            Title = dto.Title,
            StartDate = dto.StartDate,
            TournamentId = dto.TournamentId
        };
    }


    public Game UpdateGameDto_Game(UpdateGameDto dto, int id) {
        return new Game {
            GameId = id,
            Title = dto.Title,
            StartDate = dto.StartDate,
            TournamentId = dto.TournamentId
        };
    }

    // public Game UpdateGameDto_Game() {

    // }
}