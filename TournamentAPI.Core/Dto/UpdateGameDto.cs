namespace TournamentAPI.Core.Dto;

public record UpdateGameDto(
    string Title,
    DateTime StartDate,
    int TournamentId
);