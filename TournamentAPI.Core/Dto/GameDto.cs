namespace TournamentAPI.Core.Dto;

public record GameDto(
    int GameId,
    string Title,
    DateTime StartDate, 
    int TournamentId, 
    string TournamentTitle
);