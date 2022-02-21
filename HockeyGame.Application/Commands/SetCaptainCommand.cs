using HockeyGame.Application.Responses;
using MediatR;

namespace HockeyGame.Application.Commands
{
  public class SetCaptainCommand : IRequest<PlayerResponse>
  {
    public int Id { get; set; }
  }
}