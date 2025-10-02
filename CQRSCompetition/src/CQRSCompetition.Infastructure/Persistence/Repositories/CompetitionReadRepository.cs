using CQRSCompetition.APP.Interfaces;
using CQRSCompetition.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSCompetition.Infastructure.Persistence.Repositories;

public class CompetitionReadRepository : ICompetitionReadRepository
{
     private readonly    AppDbContext _context;

     public CompetitionReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Competition>> GetAllAsync()
     {
          var books = await _context.Competitions.ToListAsync();
          return books;
     }

     public  async Task<Competition?> GetByIdAsync(long id)
     {
          return await _context.Competitions.FindAsync(id);
     }
}