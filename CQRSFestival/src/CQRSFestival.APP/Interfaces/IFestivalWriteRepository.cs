using CQRSFestival.Domain.Entities;

namespace CQRSFestival.APP.Interfaces;

public interface IFestivalWriteRepository
{
    Task<long> AddAsync(Festival festival);
    Task UpdateAsync(Festival festival);
    Task DeleteAsync(long festivalId);
}