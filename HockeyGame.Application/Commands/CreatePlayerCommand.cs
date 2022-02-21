using HockeyGame.Application.Responses;
using MediatR;

namespace HockeyGame.Application.Commands
{
  public class CreatePlayerCommand : IRequest<PlayerResponse>
  {
    public int Number { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public bool IsCaptain { get; set; }
    public int TeamId { get; set; }
  }
}