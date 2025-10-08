using Microsoft.AspNetCore.Mvc;
using MongoTeacher.App.Interfaces;
using MongoTeacher.Domain;

namespace MongoTeacher.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Teacher>>> GetAll()
    {
        var teachers = await _teacherService.GetAllAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetById(long id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        if (teacher == null)
            return NotFound();

        return Ok(teacher);
    }

    [HttpPost]
    public async Task<ActionResult<Teacher>> Create([FromBody] Teacher teacher)
    {
        var created = await _teacherService.CreateAsync(teacher);
        return Created($"api/teachers/{created.Id}", created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _teacherService.DeleteAsync(id);
        return NoContent();
    }
}