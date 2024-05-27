namespace TournamentAPI.Core.Entities;

#nullable disable
public class Game {
    public int GameId { get; set; }
    public string Title { get; set; } 
    public DateTime StartDate { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
}