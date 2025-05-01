using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Students.Ports.InBounds.Applications;
using SaM.Modules.Students.Web.Factories;
using SaM.Modules.Students.Web.Payloads;

namespace SaM.Modules.Students.Web.Controllers;

public class StudentController(
    IStudentsApplication studentsApplication,
    StudentViewModelFactory studentViewModelFactory
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var students = await studentsApplication.GetAllAsync();

        return Ok(studentViewModelFactory.CreateFromEntity(students));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var student = await studentsApplication.GetByIdAsync(id);

        return Ok(studentViewModelFactory.CreateFromEntity(student));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] StudentCreationPayload creationPayload)
    {
        var createdStudent = await studentsApplication.CreateAsync(creationPayload);

        return Created($"students/{createdStudent.Id}", studentViewModelFactory.CreateFromEntity(createdStudent));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] StudentUpdatePayload updatePayload)
    {
        var updatedStudent = await studentsApplication.UpdateAsync(id, updatePayload);

        return Ok(studentViewModelFactory.CreateFromEntity(updatedStudent));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await studentsApplication.DeleteAsync(id);

        return NoContent();
    }
}