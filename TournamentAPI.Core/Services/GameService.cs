using OneOf;
using OneOf.Types;
using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Interfaces;

namespace TournamentAPI.Core.Services;

public class GameService : IGameService {
    private readonly IUoW _unitOfWork;
    private readonly ITournamentApiMapper _mapper;


    public GameService(IUoW unitOfWork, ITournamentApiMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<IEnumerable<GameDto>> GetAllGamesAsync() {
        var games = await _unitOfWork.GameRepository.GetAllAsync();
        return games.Select(g => _mapper.Game_GameDto(g));
    }

    
    public async Task<OneOf<GameDto, NotFound>> GetGameByIdAsync(int id) {
        var result = await _unitOfWork.GameRepository.GetAsync(id);

        return result.Match<OneOf<GameDto, NotFound>>(
            g => _mapper.Game_GameDto(g),
            n => n
        );
    }

    
    public async Task<GameDto> CreateGameAsync(CreateGameDto createGameDto) {
        var game = _mapper.CreateGameDto_Game(createGameDto);
        var added = await _unitOfWork.GameRepository.Add(game);
        await _unitOfWork.CompleteAsync();

        return _mapper.Game_GameDto(added); 
    }

    
    public async Task<OneOf<GameDto, NotFound>> UpdateGameAsync(UpdateGameDto updateGameDto, int id) {
        var game = _mapper.UpdateGameDto_Game(updateGameDto, id);
        var result = await _unitOfWork.GameRepository.Update(game);
        await _unitOfWork.CompleteAsync();

        return result.Match<OneOf<GameDto, NotFound>>(
            g => _mapper.Game_GameDto(g), 
            n => n
        ); 
    }

    
    public async Task<OneOf<Success, NotFound>> RemoveGameAsync(int id) {
        var result = await _unitOfWork.GameRepository.Remove(id);
        await _unitOfWork.CompleteAsync();

        return result.Match<OneOf<Success, NotFound>>(
            s => s, 
            n => n
        ); 
    }
}