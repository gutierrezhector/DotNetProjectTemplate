using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Web.Abstractions;
using SaM.Modules.Teachers.Web.Payloads;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.Controllers;

public class TeachersController(
    ITeacherApplication teacherApplication,
    Mapper<Teacher, TeacherViewModel> teacherViewModelMapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var teachers = await teacherApplication.GetAllAsync();

        return Ok(teacherViewModelMapper.Map(teachers));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var teacher = await teacherApplication.GetByIdAsync(id);

        return Ok(teacherViewModelMapper.Map(teacher));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TeacherCreationPayload creationPayload)
    {
        var newTeacher = await teacherApplication.Create(creationPayload.ToCandidate());
        return Created($"teachers/{newTeacher.Id}", teacherViewModelMapper.Map(newTeacher));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherUpdatePayload teacherUpdatePayload)
    {
        var updatedTeacher = await teacherApplication.UpdateAsync(id, teacherUpdatePayload.ToCandidate());

        return Ok(teacherViewModelMapper.Map(updatedTeacher));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await teacherApplication.DeleteAsync(id);

        return NoContent();
    }
}