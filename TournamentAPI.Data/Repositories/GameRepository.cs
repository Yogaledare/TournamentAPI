using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;
using OneOf;
using OneOf.Types;
using TournamentAPI.Core.Interfaces;

namespace TournamentAPI.Data.Repositories;

public class GameRepository : IGameRepository {
    private readonly TournamentApiContext _context;

    public GameRepository(TournamentApiContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Game>> GetAllAsync() {
        var list = await _context.Games.ToListAsync();
        return list;
    }

    public Task<OneOf<Game, NotFound>> GetAsync(int id) {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(int id) {
        throw new NotImplementedException();
    }

    public Task Add(Game game) {
        throw new NotImplementedException();
    }

    public Task<OneOf<Game, NotFound>> Update(Game game) {
        throw new NotImplementedException();
    }

    public Task<OneOf<Game, NotFound>> Remove(int id) {
        throw new NotImplementedException();
    }
}