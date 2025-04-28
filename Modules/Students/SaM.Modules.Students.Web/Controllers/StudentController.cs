using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Ports.InBounds.Applications;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Web.Payloads;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Students.Web.Controllers;

public class StudentController(
    IStudentsApplication studentsApplication,
    Mapper<IStudent, StudentViewModel> studentViewModelMapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var students = await studentsApplication.GetAllAsync();

        return Ok(studentViewModelMapper.Map(students));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var student = await studentsApplication.GetByIdAsync(id);

        return Ok(studentViewModelMapper.Map(student));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] StudentCreationPayload creationPayload)
    {
        var createdStudent = await studentsApplication.CreateAsync(creationPayload);

        return Created($"students/{createdStudent.Id}", studentViewModelMapper.Map(createdStudent));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] StudentUpdatePayload updatePayload)
    {
        var updatedStudent = await studentsApplication.UpdateAsync(id, updatePayload);

        return Ok(studentViewModelMapper.Map(updatedStudent));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await studentsApplication.DeleteAsync(id);

        return NoContent();
    }
}