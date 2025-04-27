using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Ports.InBounds.Applications;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Web.Payloads;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.Controllers;

public class TeachersController(
    ITeachersApplication teachersApplication,
    Mapper<ITeacher, TeacherViewModel> teacherViewModelMapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var teachers = await teachersApplication.GetAllAsync();

        return Ok(teacherViewModelMapper.Map(teachers));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var teacher = await teachersApplication.GetByIdAsync(id);

        return Ok(teacherViewModelMapper.Map(teacher));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TeacherCreationPayload creationPayload)
    {
        var newTeacher = await teachersApplication.Create(creationPayload);
        return Created($"teachers/{newTeacher.Id}", teacherViewModelMapper.Map(newTeacher));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherUpdatePayload teacherUpdatePayload)
    {
        var updatedTeacher = await teachersApplication.UpdateAsync(id, teacherUpdatePayload);

        return Ok(teacherViewModelMapper.Map(updatedTeacher));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await teachersApplication.DeleteAsync(id);

        return NoContent();
    }
}