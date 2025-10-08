using MongoStudent.Domain;

namespace MongoStudent.App.Interfaces;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<long> AddAsync(Student student);
    Task DeleteAsync(Student student);
    Task<Student> GetByIdAsync(long id);
}