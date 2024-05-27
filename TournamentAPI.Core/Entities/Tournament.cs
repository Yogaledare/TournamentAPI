namespace TournamentAPI.Core.Entities;

#nullable disable
public class Tournament {
    public int TournamentId { get; set; }
    public string Title { get; set; }  
    public DateTime StartDate { get; set; }
    public ICollection<Game> Game { get; set; } 
}