using CQRSTeam.APP.Interfaces;
using CQRSTeam.Domain.Entities;

namespace CQRSTeam.Infastructure.Persistence.Repositories;

public class TeamWriteRepository : ITeamWriteRepository
{
    private readonly AppDbContext _context;

    public TeamWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return team.Id;
    }

    public async Task DeleteAsync(long teamId)
    {
         _context.Remove(_context.Teams.Single(x => x.Id == teamId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Team team)
    {
        _context.Teams.Update(team);
        return _context.SaveChangesAsync();
    }
}