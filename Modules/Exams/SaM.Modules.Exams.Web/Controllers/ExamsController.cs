using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Applications;
using SaM.Modules.Exams.Web.Payloads;
using SaM.Modules.Exams.Web.ViewModels;

namespace SaM.Modules.Exams.Web.Controllers;

public class ExamsController(
    IExamsApplication application,
    Mapper<Exam, ExamViewModel> examViewModelMapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var exams = await application.GetAllAsync();

        return Ok(examViewModelMapper.MapNonNullable(exams));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var exam = await application.GetByIdAsync(id);

        return Ok(examViewModelMapper.MapNonNullable(exam));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ExamCreationPayload creationPayload)
    {
        var newExam = await application.CreateAsync(creationPayload);
        return Created($"exams/{newExam.Id}", newExam);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExamUpdatePayload updatePayload)
    {
        var updatedExam = await application.UpdateAsync(id, updatePayload);

        return Ok(examViewModelMapper.MapNonNullable(updatedExam));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await application.DeleteAsync(id);

        return NoContent();
    }
}