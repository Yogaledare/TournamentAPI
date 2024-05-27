using TournamentAPI.Core.Entities;

namespace TournamentAPI.Core.Dto;

public record TournamentDto(
    int TournamentId,
    string Title,
    DateTime StartDate, 
    List<GameDto> Games
) {
    public DateTime EndDate => StartDate.AddMonths(3);
}