using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;

namespace TournamentAPI.Data.Repositories;

public interface IGameRepository {
    Task<IEnumerable<Game>> GetAllGames();
}

public class GameRepository : IGameRepository {
    private readonly TournamentApiContext _context;

    public GameRepository(TournamentApiContext context) {
        _context = context;
    }


    public async Task<IEnumerable<Game>> GetAllGames() {
        var list = await _context.Games.ToListAsync();
        return list;
    }
}