using CQRSShow.Domain.Entities;

namespace CQRSShow.APP.Interfaces;

public interface IShowWriteRepository
{
    Task<long> AddAsync(Show show);
    Task UpdateAsync(Show show);
    Task DeleteAsync(long showId);
}