using CQRSReferee.APP.Interfaces;
using CQRSReferee.Domain.Entities;

namespace CQRSReferee.Infastructure.Persistence.Repositories;

public class RefereeWriteRepository : IRefereeWriteRepository
{
    private readonly AppDbContext _context;

    public RefereeWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(Referee referee)
    {
        await _context.Referees.AddAsync(referee);
        await _context.SaveChangesAsync();
        return referee.Id;
    }

    public async Task DeleteAsync(long refereeId)
    {
         _context.Remove(_context.Referees.Single(x => x.Id == refereeId));
         await _context.SaveChangesAsync(); 
    }

    public Task UpdateAsync(Referee referee)
    {
        _context.Referees.Update(referee);
        return _context.SaveChangesAsync();
    }
}