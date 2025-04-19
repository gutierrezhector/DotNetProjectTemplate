using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Students.Web.Abstractions;
using SaM.Modules.Students.Web.Candidates;
using SaM.Modules.Students.Web.Payloads;

namespace SaM.Modules.Students.Web.Controllers;

public class StudentController(
    IStudentsApplication studentsApplication
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await studentsApplication.GetAllAsync();

        return Ok(students);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await studentsApplication.GetByIdAsync(id);

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentPayload payload)
    {
        var student = await studentsApplication.Create(payload.ToCandidate());

        return Created($"students/{student.Id}", student);
    }
}