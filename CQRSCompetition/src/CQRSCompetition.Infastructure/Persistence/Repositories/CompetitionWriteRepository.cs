using CQRSCompetition.APP.Interfaces;
using CQRSCompetition.Domain.Entities;

namespace CQRSCompetition.Infastructure.Persistence.Repositories;

public class CompetitionWriteRepository : ICompetitionWriteRepository
{
    private readonly AppDbContext _context;

    public CompetitionWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Competition competition)
    {
        await _context.Competitions.AddAsync(competition);
        await _context.SaveChangesAsync();
        return competition.Id;
    }

    public async Task DeleteAsync(long competitionId)
    {
         _context.Remove(_context.Competitions.Single(x => x.Id == competitionId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Competition competition)
    {
        _context.Competitions.Update(competition);
        return _context.SaveChangesAsync();
    }
}