using Festival.Domain.Entities;

namespace Festival.Application.Interfaces;

public interface IFestivalRepository
{
    Task<Blog?> SelectByIdAsync(long id);
    Task<List<Blog>> SelectAllAsync();
    Task<List<Blog>> SelectAllPagedAsync(int skip, int take);
    Task InsertAsync(Blog blog);
    Task UpdateAsync(Blog blog);
    Task RemoveAsync(Blog blog);
}
