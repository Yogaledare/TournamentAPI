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
    void Add(Tournament tournament); 
    void Update(Tournament tournament); 
    void Remove(Tournament tournament); 
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

    public Task<bool> AnyAsync(int id) {
        throw new NotImplementedException();
    }

    public void Add(Tournament tournament) {
        throw new NotImplementedException();
    }

    public void Update(Tournament tournament) {
        throw new NotImplementedException();
    }

    public void Remove(Tournament tournament) {
        throw new NotImplementedException();
    }
}
