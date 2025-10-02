using CQRSFestival.APP.Interfaces;
using CQRSFestival.Domain.Entities;

namespace CQRSFestival.Infastructure.Persistence.Repositories;

public class FestivalWriteRepository : IFestivalWriteRepository
{
    private readonly AppDbContext _context;

    public FestivalWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Festival festival)
    {
        await _context.Festivals.AddAsync(festival);
        await _context.SaveChangesAsync();
        return festival.Id;
    }

    public async Task DeleteAsync(long festivalId)
    {
         _context.Remove(_context.Festivals.Single(x => x.Id == festivalId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Festival festival)
    {
        _context.Festivals.Update(festival);
        return _context.SaveChangesAsync();
    }
}