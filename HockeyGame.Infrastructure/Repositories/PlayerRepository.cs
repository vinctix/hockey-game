using HockeyGame.Application.Exceptions;
using HockeyGame.Core.Entities;
using HockeyGame.Core.Repositories;
using HockeyGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HockeyGame.Infrastructure.Repositories
{
  public class PlayerRepository : IPlayerRepository
  {
    private readonly HockeyGameContext _context;

    public PlayerRepository(HockeyGameContext context) {
      _context = context;
    }

    public async Task<Player> CreateAsync(Player player)
    {
      await _context.Players.AddAsync(player);
      await _context.SaveChangesAsync();
      return player;
    }

    public async Task<Player> GetPlayerByIdAsync(int id)
    {
      try
      {
        return await _context.Players.FirstAsync(x => x.Id == id);
      }
      catch (InvalidOperationException)
      {
        throw new PlayerNotFoundException();
      }
    }

    public async Task<Player> UpdateAsync(Player player)
    {
      _context.Players.Update(player);
      await _context.SaveChangesAsync();
      return player;
    }
  }
}