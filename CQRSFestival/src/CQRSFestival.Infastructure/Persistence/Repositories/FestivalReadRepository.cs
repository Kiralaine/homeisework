using CQRSFestival.APP.Interfaces;
using CQRSFestival.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSFestival.Infastructure.Persistence.Repositories;

public class FestivalReadRepository : IFestivalReadRepository
{
     private readonly    AppDbContext _context;

     public FestivalReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Festival>> GetAllAsync()
     {
          var books = await _context.Festivals.ToListAsync();
          return books;
     }

     public  async Task<Festival?> GetByIdAsync(long id)
     {
          return await _context.Festivals.FindAsync(id);
     }
}