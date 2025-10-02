using CQRSPlayer.APP.Interfaces;
using CQRSPlayer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSPlayer.Infastructure.Persistence.Repositories;

public class PlayerReadRepository : IPlayerReadRepository
{
     private readonly    AppDbContext _context;

     public PlayerReadRepository(AppDbContext context)
     {
          _context = context;
          
     }
     public async Task<List<Player>> GetAllAsync()
     {
          var books = await _context.Players.ToListAsync();
          return books;
     }

     public  async Task<Player?> GetByIdAsync(long id)
     {
          return await _context.Players.FindAsync(id);
     }
}