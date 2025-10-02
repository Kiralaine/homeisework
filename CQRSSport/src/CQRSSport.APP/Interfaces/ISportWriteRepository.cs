using CQRSSport.Domain.Entities;

namespace CQRSSport.APP.Interfaces;

public interface ISportWriteRepository
{
    Task<long> AddAsync(Sport sport);
    Task UpdateAsync(Sport sport);
    Task DeleteAsync(long sportId);
}