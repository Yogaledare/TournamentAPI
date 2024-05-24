namespace TournamentAPI.Dto;

public record CreateTournamentDto(
    string Title,
    DateTime StartDate
);