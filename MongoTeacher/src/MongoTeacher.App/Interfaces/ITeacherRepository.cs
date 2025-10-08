using MongoTeacher.Domain;

namespace MongoTeacher.App.Interfaces;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<long> AddAsync(Teacher teacher);
    Task DeleteAsync(Teacher teacher);
    Task<Teacher> GetByIdAsync(long id);
}