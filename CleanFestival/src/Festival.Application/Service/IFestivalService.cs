using Festival.Application.Dtos;

namespace Festival.Application.Service;

public interface IFestivalService
{
    Task<FestivalGetDto?> GetByIdAsync(long id);
    Task<List<FestivalGetDto>> GetAllAsync();
    Task<List<FestivalGetDto>> GetAllPagedAsync(FestivalFilterParams filterParams);
    Task AddAsync(FestivalCreateDto dto);
    Task UpdateAsync(long id, FestivalUpdateDto dto);
    Task RemoveAsync(long id);
}
