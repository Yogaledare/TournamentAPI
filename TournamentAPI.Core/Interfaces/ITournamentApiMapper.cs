using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Entities;

namespace TournamentAPI.Core.Interfaces;

public interface ITournamentApiMapper {
    // Tournament UpdateTournamentDto_Tournament(int id, CreateTournamentDto dto);
    TournamentDto Tournament_TournamentDto(Tournament tournament);
    GameDto Game_GameDto(Game game);
    Tournament CreateTournamentDto_Tournament(CreateTournamentDto dto);
    Tournament UpdateTournamentDto_Tournament(UpdateTournamentDto dto, int id);
    Game CreateGameDto_Game(CreateGameDto dto);
    Game UpdateGameDto_Game(UpdateGameDto dto, int id);
}