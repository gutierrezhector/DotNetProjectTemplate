using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Grades.Ports.InBounds.Applications;
using SaM.Modules.Grades.Web.Factories;
using SaM.Modules.Grades.Web.Payloads;

namespace SaM.Modules.Grades.Web.Controllers;

[ApiController]
[Route("api/grades")]
public class GradesController(
    IGradesApplication gradesApplication,
    GradeViewModelFactory gradeViewModelFactory
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var grade = await gradesApplication.GetByIdAsync(id);

        return Ok(gradeViewModelFactory.CreateFromEntity(grade));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] GradeCreationPayload creationPayload)
    {
        var newGrade = await gradesApplication.CreateAsync(creationPayload);
        return Created($"grades/{newGrade.Id}", gradeViewModelFactory.CreateFromEntity(newGrade));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GradeUpdatePayload updatePayload)
    {
        var updatedGrade = await gradesApplication.UpdateAsync(id, updatePayload);

        return Ok(gradeViewModelFactory.CreateFromEntity(updatedGrade));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await gradesApplication.DeleteAsync(id);

        return NoContent();
    }
}