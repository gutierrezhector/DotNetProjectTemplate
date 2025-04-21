using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Web.Abstractions;
using SaM.Modules.Grades.Web.Payloads;
using SaM.Modules.Grades.Web.ViewModels;

namespace SaM.Modules.Grades.Web.Controllers;

public class GradesController(
    IGradesApplication gradesApplication,
    Mapper<Grade, GradeViewModel> gradeViewModelMapper
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var grade = await gradesApplication.GetByIdAsync(id);

        return Ok(gradeViewModelMapper.Map(grade));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] GradeCreationPayload creationPayload)
    {
        var newGrade = await gradesApplication.CreateAsync(creationPayload.ToCandidate());
        return Created($"grades/{newGrade.Id}", gradeViewModelMapper.Map(newGrade));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GradeUpdatePayload updatePayload)
    {
        var updatedGrade = await gradesApplication.UpdateAsync(id, updatePayload.ToCandidate());

        return Ok(gradeViewModelMapper.Map(updatedGrade));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await gradesApplication.DeleteAsync(id);

        return NoContent();
    }
}