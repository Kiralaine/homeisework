using Competition.Domain.Entities;

namespace Competition.Application.Interfaces;

public interface ICompetitionRepository
{
    Task<Blog?> SelectByIdAsync(long id);
    Task<List<Blog>> SelectAllAsync();
    Task<List<Blog>> SelectAllPagedAsync(int skip, int take);
    Task InsertAsync(Blog blog);
    Task UpdateAsync(Blog blog);
    Task RemoveAsync(Blog blog);
}
