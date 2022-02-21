using HockeyGame.Core.Entities;

namespace HockeyGame.Core.Repositories
{
  public interface IPlayerRepository
  {
    Task<Player> GetPlayerByIdAsync(int id);
    Task<Player> UpdateAsync(Player player);
    Task<Player> CreateAsync(Player player);
  }
}