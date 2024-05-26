using TournamentAPI.Core.Entities;
using OneOf;
using OneOf.Types;


namespace TournamentAPI.Core.Interfaces;

public interface IGameRepository {
    Task<IEnumerable<Game>> GetAllAsync();
    Task<OneOf<Game, NotFound>> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    Task Add(Game game);
    Task<OneOf<Game, NotFound>> Update(Game game);
    Task<OneOf<Game, NotFound>> Remove(int id);
    
}