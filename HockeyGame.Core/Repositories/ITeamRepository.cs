using HockeyGame.Core.Entities;

namespace HockeyGame.Core.Repositories
{
  public interface ITeamRepository
  {
    Task<Team> GetTeamByYearAsync(int year);
    Task<Team> GetTeamByIdAsync(int id);
    Task UpdateTeamAsync(Team team);
  }
}