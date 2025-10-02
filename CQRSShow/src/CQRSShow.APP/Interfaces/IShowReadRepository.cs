using CQRSShow.Domain.Entities;

namespace CQRSShow.APP.Interfaces;

public interface IShowReadRepository
{
    Task<Show?> GetByIdAsync(long id);
    Task<List<Show>> GetAllAsync();
}