using CQRSTeam.Domain.Entities;

namespace CQRSTeam.APP.Interfaces;

public interface ITeamReadRepository
{
    Task<Team?> GetByIdAsync(long id);
    Task<List<Team>> GetAllAsync();
}