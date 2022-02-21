using AutoMapper;
using HockeyGame.Application.Responses;
using HockeyGame.Core.Entities;

namespace HockeyGame.Application.Mappers;

public class TeamMappingProfile: Profile
{
    public TeamMappingProfile()
    {
        CreateMap<Team, TeamResponse>().ReverseMap();
    }
}