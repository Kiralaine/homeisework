using MongoTeacher.App.Interfaces;
using MongoTeacher.Domain;

namespace MongoTeacher.App.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    
    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Teacher> GetByIdAsync(long id)
    {
        return await _teacherRepository.GetByIdAsync(id);
    }

    public async  Task<List<Teacher>> GetAllAsync()
    {
        return await _teacherRepository.GetAllAsync();
    }

    public async Task<Teacher> CreateAsync(Teacher teacher)
    {
        await _teacherRepository.AddAsync(teacher);
        return teacher;
    }

    public async Task DeleteAsync(long id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        await _teacherRepository.DeleteAsync(teacher);
    }
}