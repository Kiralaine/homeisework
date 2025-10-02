using CQRSCouch.APP.Interfaces;
using CQRSCouch.Domain.Entities;

namespace CQRSCouch.Infastructure.Persistence.Repositories;

public class CouchWriteRepository : ICouchWriteRepository
{
    private readonly AppDbContext _context;

    public CouchWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Couch couch)
    {
        await _context.Couchs.AddAsync(couch);
        await _context.SaveChangesAsync();
        return couch.Id;
    }

    public async Task DeleteAsync(long couchId)
    {
         _context.Remove(_context.Couchs.Single(x => x.Id == couchId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Couch couch)
    {
        _context.Couchs.Update(couch);
        return _context.SaveChangesAsync();
    }
}