using OneOf;
using OneOf.Types;
using TournamentAPI.Core.Dto;

namespace TournamentAPI.Core.Interfaces;

public interface IGameService {
    Task<IEnumerable<GameDto>> GetAllGamesAsync();
    Task<OneOf<GameDto, NotFound>> GetGameByIdAsync(int id);
    Task<GameDto> CreateGameAsync(CreateGameDto createGameDto);
    Task<OneOf<GameDto, NotFound>> UpdateGameAsync(UpdateGameDto updateGameDto, int id);
    Task<OneOf<Success, NotFound>> RemoveGameAsync(int id);
}