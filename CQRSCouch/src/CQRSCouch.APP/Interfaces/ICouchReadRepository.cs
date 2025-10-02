using CQRSCouch.Domain.Entities;

namespace CQRSCouch.APP.Interfaces;

public interface ICouchReadRepository
{
    Task<Couch?> GetByIdAsync(long id);
    Task<List<Couch>> GetAllAsync();
}