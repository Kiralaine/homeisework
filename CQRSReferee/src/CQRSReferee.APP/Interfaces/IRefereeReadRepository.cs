using CQRSReferee.Domain.Entities;

namespace CQRSReferee.APP.Interfaces;

public interface IRefereeReadRepository
{
    Task<Referee?> GetByIdAsync(long id);
    Task<List<Referee>> GetAllAsync();
}