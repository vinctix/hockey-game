using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HockeyGame.Application.Commands;
using HockeyGame.Application.Exceptions;
using HockeyGame.Application.Handlers.CommandHandlers;
using HockeyGame.Core.Repositories;
using HockeyGame.Infrastructure.Repositories;
using Xunit;

namespace HockeyGame.Application.Tests;

public class SetCaptainHandlerTests
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public SetCaptainHandlerTests()
    {
        var dbContext = HockeyGameContextFactory.CreateContext();
        _teamRepository = new TeamRepository(dbContext);
        _playerRepository = new PlayerRepository(dbContext);
        _mapper = MapperFactory.CreateMapper();
    }
    
    [Fact]
    public async Task SetCaptainHandlerShouldReturnReplaceCaptain()
    {
        const int playerId = 1;
        const int teamId = 1;
        await CheckSetCaptainResponse(playerId);
        await CheckTeamContainsOnlyOneCaptainResponse(teamId, playerId);
    }

    private async Task CheckSetCaptainResponse(int id)
    {
        var useCase = new SetCaptainHandler(_playerRepository, _mapper, _teamRepository);
        var request = new SetCaptainCommand() { Id = id };
        var response = await useCase.Handle(request, CancellationToken.None);
        Assert.True(response.Id == id && response.IsCaptain);
    }
    
    private async Task CheckTeamContainsOnlyOneCaptainResponse(int teamId, int captainId)
    {
        var team = await _teamRepository.GetTeamByIdAsync(teamId);
        foreach (var player in team.Players)
        {
            var isSupposedCaptain = player.Id == captainId;
            Assert.True(player.IsCaptain == isSupposedCaptain);
        }
    }
    
    [Fact]
    public async Task SetCaptainHandlerShouldThrowExceptionWhenPlayerNotFound()
    {
        var useCase = new SetCaptainHandler(_playerRepository, _mapper, _teamRepository);
        var request = new SetCaptainCommand() { Id = 123465789 };
        
        var testCode = () => useCase.Handle(request, CancellationToken.None);
        await Assert.ThrowsAsync<PlayerNotFoundException>(testCode);
    }
    
}