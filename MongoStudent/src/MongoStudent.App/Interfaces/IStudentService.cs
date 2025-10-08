using MongoStudent.Domain;

namespace MongoStudent.App.Interfaces;

public interface IStudentService
{
    Task<Student> GetByIdAsync(long id);
    Task<List<Student>> GetAllAsync();
    Task<Student> CreateAsync(Student student);
    Task DeleteAsync(long id);
}