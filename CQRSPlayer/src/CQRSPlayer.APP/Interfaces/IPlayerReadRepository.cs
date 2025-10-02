using CQRSPlayer.Domain.Entities;

namespace CQRSPlayer.APP.Interfaces;

public interface IPlayerReadRepository
{
    Task<Player?> GetByIdAsync(long id);
    Task<List<Player>> GetAllAsync();
}