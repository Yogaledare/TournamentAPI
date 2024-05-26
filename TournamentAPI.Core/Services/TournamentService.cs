using TournamentAPI.Core.Dto;
using TournamentAPI.Core.Interfaces;
using OneOf;
using OneOf.Types;

namespace TournamentAPI.Core.Services;

public class TournamentService : ITournamentService {
    private readonly IUoW _unitOfWork;
    private readonly ITournamentApiMapper _mapper;


    public TournamentService(IUoW unitOfWork, ITournamentApiMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<IEnumerable<TournamentDto>> GetAllTournamentsAsync() {
        var tournaments = await _unitOfWork.TournamentRepository.GetAllAsync();
        return tournaments.Select(t => _mapper.Tournament_TournamentDto(t));
    }


    public async Task<OneOf<TournamentDto, NotFound>> GetTournamentByIdAsync(int id) {
        var result = await _unitOfWork.TournamentRepository.GetAsync(id);

        return result.Match<OneOf<TournamentDto, NotFound>>(
            t => _mapper.Tournament_TournamentDto(t),
            n => n
        );
    }


    public async Task<TournamentDto> CreateTournamentAsync(CreateTournamentDto createTournamentDto) {
        var tournament = _mapper.CreateTournamentDto_Tournament(createTournamentDto);
        var added = await _unitOfWork.TournamentRepository.Add(tournament);
        await _unitOfWork.CompleteAsync();

        return _mapper.Tournament_TournamentDto(added); 
    }


    public async Task<OneOf<TournamentDto, NotFound>> UpdateTournamentAsync(UpdateTournamentDto dto, int id) {
        var tournament = _mapper.UpdateTournamentDto_Tournament(dto, id);
        var result = await _unitOfWork.TournamentRepository.Update(tournament);
        await _unitOfWork.CompleteAsync();

        return result.Match<OneOf<TournamentDto, NotFound>>(
            t => _mapper.Tournament_TournamentDto(t), 
            n => n
        ); 
    }


    public async Task<OneOf<TournamentDto, NotFound>> RemoveTournamentAsync(int id) {
        var result = await _unitOfWork.TournamentRepository.Remove(id);

        return result.Match<OneOf<TournamentDto, NotFound>>(
            t => _mapper.Tournament_TournamentDto(t),
            n => n
        ); 
    }
    

}