using TournamentAPI.Core.Entities;
using TournamentAPI.Dto;

namespace TournamentAPI.Mappers;

public interface ITournamentApiMapper {
    TournamentDto Tournament_TournamentDto(Tournament tournament);
    GameDto Game_GameDto(Game game);
    Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto);
    Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto, int id);
}

public class TournamentApiMapper : ITournamentApiMapper {
    public TournamentDto Tournament_TournamentDto(Tournament tournament) {
        return new TournamentDto(tournament.Title, tournament.StartDate);
    }

    public GameDto Game_GameDto(Game game) {
        return new GameDto(game.Title, game.StartDate);
    }
    
    public Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto) {
        return new Tournament {
            Title = dto.Title,
            StartDate = dto.StartDate, 
        }; 

    }

    public Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto, int id) {
        return new Tournament {
            TournamentId = id,
            Title = dto.Title,
            StartDate = dto.StartDate, 
        }; 

    }
    
}