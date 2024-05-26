using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Entities;

namespace TournamentAPI.Core.Interfaces;

public interface ITournamentApiMapper {
    TournamentDto Tournament_TournamentDto(Tournament tournament);
    GameDto Game_GameDto(Game game);
    Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto);
    
    Tournament UpdateTournamentDto_Tournament(UpdateTournamentDto dto, int id);
    // Tournament UpdateTournamentDto_Tournament(int id, CreateTournamentDto dto);
}