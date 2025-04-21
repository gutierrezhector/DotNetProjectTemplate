using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Web.Abstractions;
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

        return Ok(examViewModelMapper.Map(exams));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var exam = await application.GetByIdAsync(id);

        return Ok(examViewModelMapper.Map(exam));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ExamCreationPayload creationPayload)
    {
        var newExam = await application.CreateAsync(creationPayload.ToCandidate());
        return Created($"exams/{newExam.Id}", newExam);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExamUpdatePayload updatePayload)
    {
        var updatedExam = await application.UpdateAsync(id, updatePayload.ToCandidate());

        return Ok(examViewModelMapper.Map(updatedExam));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await application.DeleteAsync(id);

        return NoContent();
    }
}