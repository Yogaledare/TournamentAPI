namespace TournamentAPI.Dto;

public record TournamentDto(
    string Title,
    DateTime StartDate
) {
    public DateTime EndDate => StartDate.AddMonths(3);
}