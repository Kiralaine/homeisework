using MongoStudent.App.Interfaces;
using MongoStudent.Domain;

namespace MongoStudent.App.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student> GetByIdAsync(long id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    public async  Task<List<Student>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Student> CreateAsync(Student student)
    {
        await _studentRepository.AddAsync(student);
        return student;
    }

    public async Task DeleteAsync(long id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        await _studentRepository.DeleteAsync(student);
    }
}