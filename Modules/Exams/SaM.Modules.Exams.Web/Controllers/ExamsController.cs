using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Exams.Ports.InBounds.Applications;
using SaM.Modules.Exams.Web.Factories;
using SaM.Modules.Exams.Web.Payloads;

namespace SaM.Modules.Exams.Web.Controllers;

[ApiController]
[Route("api/exams")]
public class ExamsController(
    IExamsApplication application,
    ExamViewModelFactory examViewModelFactory
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var exams = await application.GetAllAsync();

        return Ok(examViewModelFactory.CreateFromEntity(exams));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var exam = await application.GetByIdAsync(id);

        return Ok(examViewModelFactory.CreateFromEntity(exam));
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

        return Ok(examViewModelFactory.CreateFromEntity(updatedExam));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await application.DeleteAsync(id);

        return NoContent();
    }
}