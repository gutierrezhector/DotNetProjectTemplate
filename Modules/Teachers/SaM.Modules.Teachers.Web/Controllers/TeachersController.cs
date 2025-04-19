using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Teachers.Web.Abstractions;
using SaM.Modules.Teachers.Web.Payloads;

namespace SaM.Modules.Teachers.Web.Controllers;

public class TeachersController(
    ITeacherApplication teacherApplication
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await teacherApplication.GetAllAsync();

        return Ok(teachers);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var teacher = await teacherApplication.GetByIdAsync(id);

        return Ok(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeacherPayload payload)
    {
        var newTeacher = await teacherApplication.Create(payload.ToCandidate());
        return Created($"teachers/{newTeacher.Id}", newTeacher);
    }
}