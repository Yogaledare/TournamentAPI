using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;
using OneOf;
using OneOf.Types;
using TournamentAPI.Core.Interfaces;

namespace TournamentAPI.Data.Repositories;

public class TournamentRepository : ITournamentRepository {
    private readonly TournamentApiContext _context;

    public TournamentRepository(TournamentApiContext context) {
        _context = context;
    }


    public async Task<IEnumerable<Tournament>> GetAllAsync() {
        var list = await _context.Tournaments
            .Include(t => t.Game)
            .ToListAsync();
        return list;
    }
    

    public async Task<OneOf<Tournament, NotFound>> GetAsync(int id) {
        var item = await _context.Tournaments
            .Include(t => t.Game)
            .FirstOrDefaultAsync(t => t.TournamentId == id);

        if (item == null) {
            return new NotFound(); 
        }

        return item; 
    }

    public async Task<bool> AnyAsync(int id) {
        var result = await _context.Tournaments.AnyAsync(t => t.TournamentId == id);

        return result; 
    }

    public async Task<Tournament> Add(Tournament tournament) {
        var result = await _context.Tournaments.AddAsync(tournament);

        var added = result.Entity; 
        return added; 

    }

    public async Task<OneOf<Tournament, NotFound>> Update(Tournament tournament) {
        var found = await _context.Tournaments
            .FirstOrDefaultAsync(t => t.TournamentId == tournament.TournamentId);

        if (found == null) return new NotFound();

        found.Title = tournament.Title;
        found.StartDate = tournament.StartDate; 
       
        return found; 
    }

    public async Task<OneOf<Success, NotFound>> Remove(int id) {
        var found = await _context.Tournaments
            .FirstOrDefaultAsync(t => t.TournamentId == id);

        if (found == null) return new NotFound();

        _context.Tournaments.Remove(found);
        return new Success(); 
    }
}
