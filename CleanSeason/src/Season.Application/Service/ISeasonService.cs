using Season.Application.Dtos;

namespace Season.Application.Service;

public interface ISeasonService
{
    Task<SeasonGetDto?> GetByIdAsync(long id);
    Task<List<SeasonGetDto>> GetAllAsync();
    Task<List<SeasonGetDto>> GetAllPagedAsync(SeasonFilterParams filterParams);
    Task AddAsync(SeasonCreateDto dto);
    Task UpdateAsync(long id, SeasonUpdateDto dto);
    Task RemoveAsync(long id);
}
