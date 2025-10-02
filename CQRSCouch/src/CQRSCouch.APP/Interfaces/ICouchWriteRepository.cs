using CQRSCouch.Domain.Entities;

namespace CQRSCouch.APP.Interfaces;

public interface ICouchWriteRepository
{
    Task<long> AddAsync(Couch couch);
    Task UpdateAsync(Couch couch);
    Task DeleteAsync(long couchId);
}