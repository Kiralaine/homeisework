using CQRSSeason.APP.Interfaces;
using CQRSSeason.Domain.Entities;

namespace CQRSSeason.Infastructure.Persistence.Repositories;

public class SeasonWriteRepository : ISeasonWriteRepository
{
    private readonly AppDbContext _context;

    public SeasonWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Season season)
    {
        await _context.Seasons.AddAsync(season);
        await _context.SaveChangesAsync();
        return season.Id;
    }

    public async Task DeleteAsync(long seasonId)
    {
         _context.Remove(_context.Seasons.Single(x => x.Id == seasonId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Season season)
    {
        _context.Seasons.Update(season);
        return _context.SaveChangesAsync();
    }
}