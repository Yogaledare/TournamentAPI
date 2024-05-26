namespace TournamentAPI.Core.Interfaces;

public interface IUoW {
    ITournamentRepository TournamentRepository { get; }
    IGameRepository GameRepository { get; }
    Task CompleteAsync();
}