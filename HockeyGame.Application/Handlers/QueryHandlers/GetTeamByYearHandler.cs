using AutoMapper;
using HockeyGame.Application.Queries;
using HockeyGame.Application.Responses;
using HockeyGame.Core.Repositories;
using MediatR;

namespace HockeyGame.Application.Handlers.QueryHandlers
{
  public class GetTeamByYearHandler: IRequestHandler<GetTeamByYearQuery, TeamResponse>
  {
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public GetTeamByYearHandler(ITeamRepository teamRepository, IMapper mapper){
      _teamRepository = teamRepository;
      _mapper = mapper;
    }

    public async Task<TeamResponse> Handle(GetTeamByYearQuery request, CancellationToken cancellationToken)
    {
      var team = await _teamRepository.GetTeamByYearAsync(request.Year);
      var response = _mapper.Map<TeamResponse>(team);
      return response;
    }
  }
}
