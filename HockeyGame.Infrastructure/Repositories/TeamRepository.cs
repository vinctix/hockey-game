using HockeyGame.Application.Exceptions;
using HockeyGame.Core.Entities;
using HockeyGame.Core.Repositories;
using HockeyGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HockeyGame.Infrastructure.Repositories
{
  public class TeamRepository : ITeamRepository
  {
    private readonly HockeyGameContext _context;

    public TeamRepository(HockeyGameContext context) {
      _context = context;
    }

    public async Task<Team> GetTeamByIdAsync(int id)
    {
      try
      {
        return await _context.Teams
          .Include(x => x.Players)
          .FirstAsync(x => x.Id == id);
      }
      catch (InvalidOperationException)
      {
        throw TeamNotFoundException.FromId(id);
      }
      
    }

    public async Task<Team> GetTeamByYearAsync(int year)
    {
      try
      {
        return await _context.Teams
          .Include(x => x.Players)
          .FirstAsync(x => x.Year == year);
      }
      catch (InvalidOperationException)
      {
        throw TeamNotFoundException.FromYear(year);
      }
    }

    public async Task UpdateTeamAsync(Team team)
    {
      _context.Teams.Update(team);
      await _context.SaveChangesAsync();
    }
  }
}