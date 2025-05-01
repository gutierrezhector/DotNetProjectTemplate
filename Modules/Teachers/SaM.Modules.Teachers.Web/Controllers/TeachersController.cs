using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Applications;
using SaM.Modules.Teachers.Web.Payloads;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.Controllers;

public class TeachersController(
    ITeachersApplication teachersApplication,
    Mapper<Teacher, TeacherViewModel> teacherViewModelMapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var teachers = await teachersApplication.GetAllAsync();

        return Ok(teacherViewModelMapper.MapNonNullable(teachers));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var teacher = await teachersApplication.GetByIdAsync(id);

        return Ok(teacherViewModelMapper.MapNonNullable(teacher));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TeacherCreationPayload creationPayload)
    {
        var newTeacher = await teachersApplication.Create(creationPayload);
        return Created($"teachers/{newTeacher.Id}", teacherViewModelMapper.MapNonNullable(newTeacher));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherUpdatePayload teacherUpdatePayload)
    {
        var updatedTeacher = await teachersApplication.UpdateAsync(id, teacherUpdatePayload);

        return Ok(teacherViewModelMapper.MapNonNullable(updatedTeacher));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await teachersApplication.DeleteAsync(id);

        return NoContent();
    }
}