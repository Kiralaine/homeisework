using Sport.Domain.Entities;

namespace Sport.Application.Interfaces;

public interface ISportRepository
{
    Task<Blog?> SelectByIdAsync(long id);
    Task<List<Blog>> SelectAllAsync();
    Task<List<Blog>> SelectAllPagedAsync(int skip, int take);
    Task InsertAsync(Blog blog);
    Task UpdateAsync(Blog blog);
    Task RemoveAsync(Blog blog);
}
