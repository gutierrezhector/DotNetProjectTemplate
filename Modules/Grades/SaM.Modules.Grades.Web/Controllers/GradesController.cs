using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Grades.Web.Abstractions;
using SaM.Modules.Grades.Web.Payloads;

namespace SaM.Modules.Grades.Web.Controllers;

public class GradesController(
    IGradesApplication gradesApplication
    ) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(GradePayload payload)
    {
        var newGrade = await gradesApplication.CreateAsync(payload.ToCandidate());
        return Created($"grades/{newGrade.Id}", newGrade);
    }
}