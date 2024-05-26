namespace TournamentAPI.Core.Dto;

public record CreateTournamentDto(
    string Title,
    DateTime StartDate
);