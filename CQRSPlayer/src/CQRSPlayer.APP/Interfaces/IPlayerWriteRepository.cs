using CQRSPlayer.Domain.Entities;

namespace CQRSPlayer.APP.Interfaces;

public interface IPlayerWriteRepository
{
    Task<long> AddAsync(Player player);
    Task UpdateAsync(Player player);
    Task DeleteAsync(long playerId);
}