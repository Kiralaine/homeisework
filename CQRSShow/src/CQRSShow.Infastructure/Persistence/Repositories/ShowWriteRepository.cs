using CQRSShow.APP.Interfaces;
using CQRSShow.Domain.Entities;

namespace CQRSShow.Infastructure.Persistence.Repositories;

public class ShowWriteRepository : IShowWriteRepository
{
    private readonly AppDbContext _context;

    public ShowWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Show show)
    {
        await _context.Shows.AddAsync(show);
        await _context.SaveChangesAsync();
        return show.Id;
    }

    public async Task DeleteAsync(long showId)
    {
         _context.Remove(_context.Shows.Single(x => x.Id == showId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Show show)
    {
        _context.Shows.Update(show);
        return _context.SaveChangesAsync();
    }
}