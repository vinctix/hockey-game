using AutoMapper;
using HockeyGame.Application.Commands;
using HockeyGame.Application.Responses;
using HockeyGame.Core.Entities;

namespace HockeyGame.Application.Mappers
{
  public class PlayerMappingProfile: Profile
  {
    public PlayerMappingProfile()
    {
      CreateMap<Player, PlayerResponse>().ReverseMap();
      CreateMap<Player, CreatePlayerCommand>().ReverseMap();
    }
  }
}