using CQRSTeam.Domain.Entities;

namespace CQRSTeam.APP.Interfaces;

public interface ITeamWriteRepository
{
    Task<long> AddAsync(Team team);
    Task UpdateAsync(Team team);
    Task DeleteAsync(long teamId);
}