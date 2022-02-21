using AutoMapper;
using HockeyGame.Application.Mappers;

namespace HockeyGame.Application.Tests;

public static class MapperFactory
{
    public static IMapper CreateMapper()
    {
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PlayerMappingProfile>();
            cfg.AddProfile<TeamMappingProfile>();
        });
        return configurationProvider.CreateMapper();
    }
}