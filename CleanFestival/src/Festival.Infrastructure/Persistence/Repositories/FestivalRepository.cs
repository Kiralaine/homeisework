using Festival.Application.Interfaces;
using Festival.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Festival.Infrastructure.Persistence.Repositories;

public class FestivalRepository : IFestivalRepository
{
    private readonly AppDbContext _context;

    public FestivalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task InsertAsync(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Blog blog)
    {
        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Blog>> SelectAllAsync()
    {
        return await _context.Blogs.ToListAsync();
    }

    public async Task<List<Blog>> SelectAllPagedAsync(int skip, int take)
    {
        return await _context.Blogs
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Blog?> SelectByIdAsync(long id)
    {
        return await _context.Blogs
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Blog blog)
    {
        _context.Blogs.Update(blog);
        await _context.SaveChangesAsync();
    }
}
