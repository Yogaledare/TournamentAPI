using TournamentAPI.Core.Entities;
using TournamentAPI.Dto;

namespace TournamentAPI.Mappers;

public interface ITournamentApiMapper {
    TournamentDto Tournament_TournamentDto(Tournament tournament);
    GameDto Game_GameDto(Game game);
}

public class TournamentApiMapper : ITournamentApiMapper {
    public TournamentDto Tournament_TournamentDto(Tournament tournament) {
        return new TournamentDto(tournament.Title, tournament.StartDate);
    }

    public GameDto Game_GameDto(Game game) {
        return new GameDto(game.Title, game.StartDate);
    }
}