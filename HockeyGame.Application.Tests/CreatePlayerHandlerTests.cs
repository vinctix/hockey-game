using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HockeyGame.Application.Commands;
using HockeyGame.Application.Handlers.CommandHandlers;
using HockeyGame.Application.Responses;
using HockeyGame.Core.Repositories;
using HockeyGame.Infrastructure.Repositories;
using Xunit;

namespace HockeyGame.Application.Tests;

public class CreatePlayerHandlerTests
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    private readonly ITeamRepository _teamRepository;
    private const int TeamId = 2;
    
    public CreatePlayerHandlerTests()
    {
        var context = HockeyGameContextFactory.CreateContext();
        _playerRepository = new PlayerRepository(context);
        _teamRepository = new TeamRepository(context);
        _mapper = MapperFactory.CreateMapper();
    }
    
    [Fact]
    public async Task CreatePlayerShouldCreateAndReturnPlayer()
    {
        var request = new CreatePlayerCommand()
        {
            Number = 1234,
            Position = "goalie",
            FirstName = "Vincent",
            LastName = "Tixier",
            IsCaptain = true,
            TeamId = TeamId
        };
        var handler = new CreatePlayerHandler(_playerRepository, _mapper, _teamRepository);
        var playerResponse = await handler.Handle(request, CancellationToken.None);
        CheckCreatePlayerResponse(request, playerResponse);
        await CheckPlayerAddedToTeam(TeamId, playerResponse.Id);
    }

    private void CheckCreatePlayerResponse(CreatePlayerCommand request, PlayerResponse playerResponse)
    {
        Assert.True(request.IsCaptain == playerResponse.IsCaptain);
        Assert.True(request.Number == playerResponse.Number);
        Assert.True(request.Position == playerResponse.Position);
        Assert.True(request.FirstName == playerResponse.FirstName);
        Assert.True(request.LastName == playerResponse.LastName);
    }

    private async Task CheckPlayerAddedToTeam(int teamId, int playerId)
    {
        var team = await _teamRepository.GetTeamByIdAsync(teamId);
        Assert.Contains(team.Players, x => x.Id == playerId);
    }
    
}