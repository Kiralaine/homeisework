using CQRSSeason.Domain.Entities;

namespace CQRSSeason.APP.Interfaces;

public interface ISeasonReadRepository
{
    Task<Season?> GetByIdAsync(long id);
    Task<List<Season>> GetAllAsync();
}