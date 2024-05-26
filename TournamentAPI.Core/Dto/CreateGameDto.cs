namespace TournamentAPI.Core.Dto;

public record CreateGameDto(
    string Title,
    DateTime StartDate,
    int TournamentId
);