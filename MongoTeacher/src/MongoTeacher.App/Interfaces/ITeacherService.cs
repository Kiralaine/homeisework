using MongoTeacher.Domain;

namespace MongoTeacher.App.Interfaces;

public interface ITeacherService
{
    Task<Teacher> GetByIdAsync(long id);
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> CreateAsync(Teacher teacher);
    Task DeleteAsync(long id);
}