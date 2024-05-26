namespace TournamentAPI.Core.Dto;

public record TournamentDto(
    int TournamentId,
    string Title,
    DateTime StartDate
) {
    public DateTime EndDate => StartDate.AddMonths(3);
}