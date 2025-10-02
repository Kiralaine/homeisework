using CQRSShow.APP.Interfaces;
using CQRSShow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSShow.Infastructure.Persistence.Repositories;

public class ShowReadRepository : IShowReadRepository
{
     private readonly    AppDbContext _context;

     public ShowReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Show>> GetAllAsync()
     {
          var books = await _context.Shows.ToListAsync();
          return books;
     }

     public  async Task<Show?> GetByIdAsync(long id)
     {
          return await _context.Shows.FindAsync(id);
     }
}