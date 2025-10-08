using MongoDB.Driver;
using MongoTeacher.App.Interfaces;
using MongoTeacher.Domain;

namespace MongoTeacher.Inf.Persistence.Repository;

public class TeacherRepository : ITeacherRepository
{
    private readonly IMongoCollection<Teacher> _teachers;

    public TeacherRepository(IMongoCollection<Teacher> teachers)
    {
        _teachers = teachers;
    }

    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _teachers.Find(FilterDefinition<Teacher>.Empty).ToListAsync();
    }

    public async Task<long> AddAsync(Teacher teacher)
    {
        if (teacher.Id == 0)
            teacher.Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        await _teachers.InsertOneAsync(teacher);
        return teacher.Id;
    }

    public Task DeleteAsync(Teacher teacher)
    {
        _teachers.DeleteOne(x => x.Id == teacher.Id);
        return Task.CompletedTask;
    }

    public Task<Teacher> GetByIdAsync(long id)
    {
       return _teachers.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}