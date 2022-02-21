using HockeyGame.Core.Entities;

namespace HockeyGame.Infrastructure.Data;

public class DataGenerator
{
    public static void Initialize(HockeyGameContext context)
    {
        if (context.Teams.Any())
        {
            return;
        }
        context.Teams.AddRange(
            GetStarWarsTeam(),
            GetCurrentTeam()
        );

        context.SaveChanges();
    }

    private static Team GetStarWarsTeam()
    {
        return new Team
        {
            Coach = "Anakin Skywalker",
            Id = 1,
            Year = 2021,
            Players = new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Number = 666,
                    FirstName = "Dark",
                    LastName = "Vador",
                    IsCaptain = true,
                    Position = "goalie"
                },
                new Player
                {
                    Id = 2,
                    Number = 11,
                    FirstName = "Ajunta",
                    LastName = "Pall",
                    IsCaptain = false,
                    Position = "left defense"
                },
                new Player
                {
                    Id = 3,
                    Number = 12,
                    FirstName = "Karness",
                    LastName = "Muur",
                    IsCaptain = false,
                    Position = "right defense"
                },
                new Player
                {
                    Id = 4,
                    Number = 13,
                    FirstName = "Marka",
                    LastName = "Ragnos",
                    IsCaptain = false,
                    Position = "center"
                },
                new Player
                {
                    Id = 5,
                    Number = 14,
                    FirstName = "Ludo",
                    LastName = "Kressh",
                    IsCaptain = false,
                    Position = "left wing"
                },
                new Player
                {
                    Id = 6,
                    Number = 15,
                    FirstName = "Naga",
                    LastName = "Sadow",
                    IsCaptain = false,
                    Position = "right wing"
                }
            }
        };
    }

    private static Team GetCurrentTeam()
    {
        return new Team()
        {
            Coach = "Matin St-Louis",
            Id = 2,
            Year = 2022,
            Players = new List<Player>
            {
                new Player
                {
                    Id = 7,
                    Number = 666,
                    FirstName = "Jack",
                    LastName = "Allen",
                    IsCaptain = false,
                    Position = "goalie"
                },
                new Player
                {
                    Id = 8,
                    Number = 11,
                    FirstName = "Ben",
                    LastName = "Chiarot",
                    IsCaptain = false,
                    Position = "left defense"
                },
                new Player
                {
                    Id = 9,
                    Number = 12,
                    FirstName = "Kale",
                    LastName = "Clague",
                    IsCaptain = false,
                    Position = "right defense"
                },
                new Player
                {
                    Id = 11,
                    Number = 14,
                    FirstName = "Jack",
                    LastName = "Evans",
                    IsCaptain = false,
                    Position = "left wing"
                },
                new Player
                {
                    Id = 12,
                    Number = 15,
                    FirstName = "Pitlick",
                    LastName = "Sadow",
                    IsCaptain = false,
                    Position = "right wing"
                }
            }
        };
    }
}