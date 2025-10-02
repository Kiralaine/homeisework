using CQRSFestival.Domain.Entities;

namespace CQRSFestival.APP.Interfaces;

public interface IFestivalReadRepository
{
    Task<Festival?> GetByIdAsync(long id);
    Task<List<Festival>> GetAllAsync();
}