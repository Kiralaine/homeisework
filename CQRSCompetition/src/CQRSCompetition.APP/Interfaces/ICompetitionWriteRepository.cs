using CQRSCompetition.Domain.Entities;

namespace CQRSCompetition.APP.Interfaces;

public interface ICompetitionWriteRepository
{
    Task<long> AddAsync(Competition competition);
    Task UpdateAsync(Competition competition);
    Task DeleteAsync(long competitionId);
}