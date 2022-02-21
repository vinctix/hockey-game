using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HockeyGame.Application.Exceptions;
using HockeyGame.Application.Handlers.QueryHandlers;
using HockeyGame.Application.Queries;
using HockeyGame.Core.Repositories;
using HockeyGame.Infrastructure.Repositories;
using Xunit;

namespace HockeyGame.Application.Tests;

public class GetTeamByYearHandlerTests
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;
    
    public GetTeamByYearHandlerTests()
    {
        _teamRepository = new TeamRepository(HockeyGameContextFactory.CreateContext());
        _mapper = MapperFactory.CreateMapper();
    }

    [Fact]
    public async Task GetTeamByYearHandlerShouldReturnCorrectTeam()
    {
        var useCase = new GetTeamByYearHandler(_teamRepository, _mapper);
        var query = new GetTeamByYearQuery() { Year = 2021 };
        var team = await useCase.Handle(query, CancellationToken.None);
        Assert.True(team.Year == 2021);
    }

    [Fact]
    public async Task GetTeamByYearHandlerShouldThrowExceptionWhenYearNotFound()
    {
        var useCase = new GetTeamByYearHandler(_teamRepository, _mapper);
        var query = new GetTeamByYearQuery() { Year = 2020 };
        var testCode = () => useCase.Handle(query, CancellationToken.None);
        await Assert.ThrowsAsync<TeamNotFoundException>(testCode);
    }
}