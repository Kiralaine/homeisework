using CQRSSport.APP.Interfaces;
using CQRSSport.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSSport.Infastructure.Persistence.Repositories;

public class SportReadRepository : ISportReadRepository
{
     private readonly    AppDbContext _context;

     public SportReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Sport>> GetAllAsync()
     {
          var books = await _context.Sports.ToListAsync();
          return books;
     }

     public  async Task<Sport?> GetByIdAsync(long id)
     {
          return await _context.Sports.FindAsync(id);
     }
}