using CQRSReferee.Domain.Entities;

namespace CQRSReferee.APP.Interfaces;

public interface IRefereeWriteRepository
{
    Task<long> AddAsync(Referee referee);
    Task UpdateAsync(Referee referee);
    Task DeleteAsync(long refereeId);
}