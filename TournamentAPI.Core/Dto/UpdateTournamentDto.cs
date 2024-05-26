namespace TournamentAPI.Core.Dto;

public record UpdateTournamentDto(
    string Title,
    DateTime StartDate
);