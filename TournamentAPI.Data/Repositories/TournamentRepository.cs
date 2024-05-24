using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;
using OneOf;
using OneOf.Types;

namespace TournamentAPI.Data.Repositories;

public interface ITournamentRepository {
    Task<IEnumerable<Tournament>> GetAllAsync();
    Task<OneOf<Tournament, NotFound>> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    Task Add(Tournament tournament);
    Task<OneOf<Tournament, NotFound>> Update(Tournament tournament);
    Task<OneOf<Tournament, NotFound>> Remove(int id);
}


public class TournamentRepository : ITournamentRepository {
    private readonly TournamentApiContext _context;

    public TournamentRepository(TournamentApiContext context) {
        _context = context;
    }


    public async Task<IEnumerable<Tournament>> GetAllAsync() {
        var list = await _context.Tournaments.ToListAsync();
        return list;
    }
    

    public async Task<OneOf<Tournament, NotFound>> GetAsync(int id) {
        var item = await _context.Tournaments.FirstOrDefaultAsync(t => t.TournamentId == id);

        if (item == null) {
            return new NotFound(); 
        }

        return item; 
    }

    public async Task<bool> AnyAsync(int id) {
        var result = await _context.Tournaments.AnyAsync(t => t.TournamentId == id);

        return result; 
    }

    public async Task Add(Tournament tournament) {
        await _context.Tournaments.AddAsync(tournament);
    }

    public async Task<OneOf<Tournament, NotFound>> Update(Tournament tournament) {
        var found = await _context.Tournaments
            .FirstOrDefaultAsync(t => t.TournamentId == tournament.TournamentId);

        if (found == null) return new NotFound();

        var updated = _context.Tournaments.Update(tournament).Entity;

        return updated; 
    }

    public async Task<OneOf<Tournament, NotFound>> Remove(int id) {
        var found = await _context.Tournaments
            .FirstOrDefaultAsync(t => t.TournamentId == id);

        if (found == null) return new NotFound();

        _context.Tournaments.Remove(found);
        return found; 
    }
}
