using CQRSSeason.APP.Interfaces;
using CQRSSeason.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSSeason.Infastructure.Persistence.Repositories;

public class SeasonReadRepository : ISeasonReadRepository
{
     private readonly    AppDbContext _context;

     public SeasonReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Season>> GetAllAsync()
     {
          var books = await _context.Seasons.ToListAsync();
          return books;
     }

     public  async Task<Season?> GetByIdAsync(long id)
     {
          return await _context.Seasons.FindAsync(id);
     }
}