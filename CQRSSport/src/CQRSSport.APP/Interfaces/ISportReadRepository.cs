using CQRSSport.Domain.Entities;

namespace CQRSSport.APP.Interfaces;

public interface ISportReadRepository
{
    Task<Sport?> GetByIdAsync(long id);
    Task<List<Sport>> GetAllAsync();
}