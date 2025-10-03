using Sport.Application.Dtos;

namespace Sport.Application.Service;

public interface ISportService
{
    Task<SportGetDto?> GetByIdAsync(long id);
    Task<List<SportGetDto>> GetAllAsync();
    Task<List<SportGetDto>> GetAllPagedAsync(SportFilterParams filterParams);
    Task AddAsync(SportCreateDto dto);
    Task UpdateAsync(long id, SportUpdateDto dto);
    Task RemoveAsync(long id);
}
