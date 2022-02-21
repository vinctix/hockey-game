using HockeyGame.Application.Responses;
using MediatR;

namespace HockeyGame.Application.Queries
{
  public class GetTeamByYearQuery: IRequest<TeamResponse>
  {
    public int Year { get; set; }
  }

}