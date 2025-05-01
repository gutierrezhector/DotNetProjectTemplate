using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Teachers.Ports.InBounds.Applications;
using SaM.Modules.Teachers.Web.Factories;
using SaM.Modules.Teachers.Web.Payloads;

namespace SaM.Modules.Teachers.Web.Controllers;

public class TeachersController(
    ITeachersApplication teachersApplication,
    TeacherViewModelFactory teacherViewModelFactory
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var teachers = await teachersApplication.GetAllAsync();

        return Ok(teacherViewModelFactory.CreateFromEntity(teachers));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var teacher = await teachersApplication.GetByIdAsync(id);

        return Ok(teacherViewModelFactory.CreateFromEntity(teacher));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TeacherCreationPayload creationPayload)
    {
        var newTeacher = await teachersApplication.Create(creationPayload);
        return Created($"teachers/{newTeacher.Id}", teacherViewModelFactory.CreateFromEntity(newTeacher));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherUpdatePayload teacherUpdatePayload)
    {
        var updatedTeacher = await teachersApplication.UpdateAsync(id, teacherUpdatePayload);

        return Ok(teacherViewModelFactory.CreateFromEntity(updatedTeacher));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await teachersApplication.DeleteAsync(id);

        return NoContent();
    }
}