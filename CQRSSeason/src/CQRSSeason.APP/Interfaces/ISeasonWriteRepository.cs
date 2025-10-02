using CQRSSeason.Domain.Entities;

namespace CQRSSeason.APP.Interfaces;

public interface ISeasonWriteRepository
{
    Task<long> AddAsync(Season season);
    Task UpdateAsync(Season season);
    Task DeleteAsync(long seasonId);
}