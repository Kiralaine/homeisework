using MongoDB.Driver;
using MongoStudent.App.Interfaces;
using MongoStudent.Domain;

namespace MongoStudent.Inf.Persistence.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly IMongoCollection<Student> _students;

    public StudentRepository(IMongoCollection<Student> students)
    {
        _students = students;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _students.Find(FilterDefinition<Student>.Empty).ToListAsync();
    }

    public async Task<long> AddAsync(Student student)
    {
        if (student.Id == 0)
            student.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        await _students.InsertOneAsync(student);
        return student.Id;
    }

    public Task DeleteAsync(Student student)
    {
        _students.DeleteOne(x => x.Id == student.Id);
        return Task.CompletedTask;
    }

    public Task<Student> GetByIdAsync(long id)
    {
       return _students.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}