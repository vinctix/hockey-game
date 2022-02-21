using AutoMapper;
using HockeyGame.Application.Commands;
using HockeyGame.Application.Responses;
using HockeyGame.Core.Entities;
using HockeyGame.Core.Repositories;
using MediatR;

namespace HockeyGame.Application.Handlers.CommandHandlers
{
  public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, PlayerResponse>
  {
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public CreatePlayerHandler(IPlayerRepository playerRepository, IMapper mapper, ITeamRepository teamRepository) {
      _playerRepository = playerRepository;
      _teamRepository = teamRepository;
      _mapper = mapper;
    }

    public async Task<PlayerResponse> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
      var playerEntity = _mapper.Map<Player>(request);
      await _playerRepository.CreateAsync(playerEntity);

      if (playerEntity.IsCaptain)
      {
        var team = await _teamRepository.GetTeamByIdAsync(playerEntity.TeamId);
        team.Captain = playerEntity;
        await _teamRepository.UpdateTeamAsync(team);
      }
      
      var playerResponse = _mapper.Map<PlayerResponse>(playerEntity);
      return playerResponse;
    }
  }
}