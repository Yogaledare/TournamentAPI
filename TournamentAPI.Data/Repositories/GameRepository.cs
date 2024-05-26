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

    public async Task<OneOf<Game, NotFound>> GetAsync(int id) {
        var item = await _context.Games.FirstOrDefaultAsync(t => t.GameId == id);

        if (item == null) {
            return new NotFound(); 
        }

        return item; 
    }

    public async Task<bool> AnyAsync(int id) {
        var result = await _context.Games.AnyAsync(t => t.GameId == id);

        return result; 
    }

    public async Task<Game> Add(Game game) {
        var result = await _context.Games.AddAsync(game);

        var added = result.Entity; 
        return added; 
    }

    public async Task<OneOf<Game, NotFound>> Update(Game game) {
        var found = await _context.Games
            .FirstOrDefaultAsync(g => g.GameId == game.GameId);

        if (found == null) {
            return new NotFound(); 
        }

        found.Title = game.Title;
        found.StartDate = game.StartDate;
        found.TournamentId = game.TournamentId;

        return found; 
    }

    public async Task<OneOf<Success, NotFound>> Remove(int id) {
        var found = await _context.Games
            .FirstOrDefaultAsync(t => t.GameId == id);

        if (found == null) return new NotFound();

        _context.Games.Remove(found);
        return new Success();
    }
}