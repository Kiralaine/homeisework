using CQRSCompetition.Domain.Entities;

namespace CQRSCompetition.APP.Interfaces;

public interface ICompetitionReadRepository
{
    Task<Competition?> GetByIdAsync(long id);
    Task<List<Competition>> GetAllAsync();
}