using CQRSSport.APP.Interfaces;
using CQRSSport.Domain.Entities;

namespace CQRSSport.Infastructure.Persistence.Repositories;

public class SportWriteRepository : ISportWriteRepository
{
    private readonly AppDbContext _context;

    public SportWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Sport sport)
    {
        await _context.Sports.AddAsync(sport);
        await _context.SaveChangesAsync();
        return sport.Id;
    }

    public async Task DeleteAsync(long sportId)
    {
         _context.Remove(_context.Sports.Single(x => x.Id == sportId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Sport sport)
    {
        _context.Sports.Update(sport);
        return _context.SaveChangesAsync();
    }
}