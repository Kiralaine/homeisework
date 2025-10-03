using Competition.Application.Dtos;

namespace Competition.Application.Service;

public interface ICompetitionService
{
    Task<CompetitionGetDto?> GetByIdAsync(long id);
    Task<List<CompetitionGetDto>> GetAllAsync();
    Task<List<CompetitionGetDto>> GetAllPagedAsync(CompetitionFilterParams filterParams);
    Task AddAsync(CompetitionCreateDto dto);
    Task UpdateAsync(long id, CompetitionUpdateDto dto);
    Task RemoveAsync(long id);
}
