using CQRSTeam.APP.Interfaces;
using CQRSTeam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSTeam.Infastructure.Persistence.Repositories;

public class TeamReadRepository : ITeamReadRepository
{
     private readonly    AppDbContext _context;

     public TeamReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Team>> GetAllAsync()
     {
          var books = await _context.Teams.ToListAsync();
          return books;
     }

     public  async Task<Team?> GetByIdAsync(long id)
     {
          return await _context.Teams.FindAsync(id);
     }
}