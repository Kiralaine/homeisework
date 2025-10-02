using CQRSCouch.APP.Interfaces;
using CQRSCouch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSCouch.Infastructure.Persistence.Repositories;

public class CouchReadRepository : ICouchReadRepository
{
     private readonly    AppDbContext _context;

     public CouchReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Couch>> GetAllAsync()
     {
          var books = await _context.Couchs.ToListAsync();
          return books;
     }

     public  async Task<Couch?> GetByIdAsync(long id)
     {
          return await _context.Couchs.FindAsync(id);
     }
}