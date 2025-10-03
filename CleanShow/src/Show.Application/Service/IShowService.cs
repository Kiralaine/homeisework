using Show.Application.Dtos;

namespace Show.Application.Service;

public interface IShowService
{
    Task<ShowGetDto?> GetByIdAsync(long id);
    Task<List<ShowGetDto>> GetAllAsync();
    Task<List<ShowGetDto>> GetAllPagedAsync(ShowFilterParams filterParams);
    Task AddAsync(ShowCreateDto dto);
    Task UpdateAsync(long id, ShowUpdateDto dto);
    Task RemoveAsync(long id);
}
