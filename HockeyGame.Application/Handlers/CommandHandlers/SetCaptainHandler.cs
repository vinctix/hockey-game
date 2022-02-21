using AutoMapper;
using HockeyGame.Application.Commands;
using HockeyGame.Application.Responses;
using HockeyGame.Core.Repositories;
using MediatR;

namespace HockeyGame.Application.Handlers.CommandHandlers
{
  public class SetCaptainHandler : IRequestHandler<SetCaptainCommand, PlayerResponse>
  {
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public SetCaptainHandler(IPlayerRepository playerRepository, IMapper mapper, ITeamRepository teamRepository)
    {
      _playerRepository = playerRepository;
      _mapper = mapper;
      _teamRepository = teamRepository;
    }

    public async Task<PlayerResponse> Handle(SetCaptainCommand request, CancellationToken cancellationToken)
    {
      var captain = await _playerRepository.GetPlayerByIdAsync(request.Id);
      
      var team = await _teamRepository.GetTeamByIdAsync(captain.TeamId);
      team.Captain = captain;
      await _teamRepository.UpdateTeamAsync(team);

      var playerResponse = _mapper.Map<PlayerResponse>(captain);
      return playerResponse;
    }
  }
}