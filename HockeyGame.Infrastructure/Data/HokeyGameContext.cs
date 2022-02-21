using HockeyGame.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HockeyGame.Infrastructure.Data
{
  public class HockeyGameContext : DbContext
  {
    public HockeyGameContext(DbContextOptions<HockeyGameContext> options)
      : base(options)
    {
      DataGenerator.Initialize(this);
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
  }
}