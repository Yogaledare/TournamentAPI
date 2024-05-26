using TournamentAPI.Core.Entities;
using OneOf;
using OneOf.Types;

namespace TournamentAPI.Core.Interfaces;

public interface ITournamentRepository {
    Task<IEnumerable<Tournament>> GetAllAsync();
    Task<OneOf<Tournament, NotFound>> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    Task<Tournament> Add(Tournament tournament);
    Task<OneOf<Tournament, NotFound>> Update(Tournament tournament);
    Task<OneOf<Success, NotFound>> Remove(int id);
}