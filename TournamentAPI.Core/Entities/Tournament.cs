namespace TournamentAPI.Core.Entities;

public class Tournament {
    public int TournamentId { get; set; }
    public string Title { get; set; } = string.Empty; 
    public DateTime StartDate { get; set; }
    public ICollection<Game> Game { get; set; } = []; 
}