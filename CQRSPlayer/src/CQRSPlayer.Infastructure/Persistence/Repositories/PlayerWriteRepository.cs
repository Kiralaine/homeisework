using CQRSPlayer.APP.Interfaces;
using CQRSPlayer.Domain.Entities;

namespace CQRSPlayer.Infastructure.Persistence.Repositories;

public class PlayerWriteRepository : IPlayerWriteRepository
{
    private readonly AppDbContext _context;

    public PlayerWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        return player.Id;
    }

    public async Task DeleteAsync(long playerId)
    {
         _context.Remove(_context.Players.Single(x => x.Id == playerId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Player player)
    {
        _context.Players.Update(player);
        return _context.SaveChangesAsync();
    }
}