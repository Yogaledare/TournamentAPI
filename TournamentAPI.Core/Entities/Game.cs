namespace TournamentAPI.Core.Entities;

public class Game {
    public int GameId { get; set; }
    public string Title { get; set; } = string.Empty; 
    public DateTime StartDate { get; set; }
    public int TournamentId { get; set; }
}