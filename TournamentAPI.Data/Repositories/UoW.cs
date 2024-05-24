using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;

namespace TournamentAPI.Data.Repositories;

public interface IUoW {
    ITournamentRepository TournamentRepository { get; }
    IGameRepository GameRepository { get; }
    Task CompleteAsync();
}

public class UoW : IUoW {
    private readonly TournamentApiContext _context;

    private TournamentRepository? _tournamentRepository;
    private IGameRepository? _gameRepository;

    public UoW(TournamentApiContext context) {
        _context = context;
    }

    public ITournamentRepository TournamentRepository {
        get { return _tournamentRepository ??= new TournamentRepository(_context); }
    }

    public IGameRepository GameRepository {
        get { return _gameRepository ??= new GameRepository(_context); }
    }
    
    public async Task CompleteAsync() {
        await _context.SaveChangesAsync();
    }
}