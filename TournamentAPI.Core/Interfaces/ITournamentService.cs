using OneOf;
using OneOf.Types;
using TournamentAPI.Core.Dto;

namespace TournamentAPI.Core.Interfaces;

public interface ITournamentService {
    Task<IEnumerable<TournamentDto>> GetAllTournamentsAsync();
    Task<OneOf<TournamentDto, NotFound>> GetTournamentByIdAsync(int id);
    Task<TournamentDto> CreateTournamentAsync(CreateTournamentDto createTournamentDto);
    Task<OneOf<TournamentDto, NotFound>> UpdateTournamentAsync(UpdateTournamentDto dto, int id);
    Task<OneOf<Success, NotFound>> RemoveTournamentAsync(int id);
}