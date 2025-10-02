using CQRSReferee.APP.Interfaces;
using CQRSReferee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSReferee.Infastructure.Persistence.Repositories;

public class RefereeReadRepository : IRefereeReadRepository
{
     private readonly    AppDbContext _context;

     public RefereeReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Referee>> GetAllAsync()
     {
          var books = await _context.Referees.ToListAsync();
          return books;
     }

     public  async Task<Referee?> GetByIdAsync(long id)
     {
          return await _context.Referees.FindAsync(id);
     }
}