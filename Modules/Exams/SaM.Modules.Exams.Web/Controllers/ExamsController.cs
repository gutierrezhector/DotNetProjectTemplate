using Microsoft.AspNetCore.Mvc;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Exams.Web.Abstractions;
using SaM.Modules.Exams.Web.Dtos;
using SaM.Modules.Exams.Web.Payloads;

namespace SaM.Modules.Exams.Web.Controllers;

public class ExamsController(
    IExamsApplication application, 
    Mapper<Exam, ExamDto> examToExamDtoMapper
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var exams = await application.GetAllAsync();

        return Ok(examToExamDtoMapper.Map(exams));
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var exam = await application.GetByIdAsync(id);

        return Ok(examToExamDtoMapper.Map(exam));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExamPayload payload)
    {
        var newExam = await application.Create(payload.ToCandidate());
        return Created($"exams/{newExam.Id}", newExam);
    }
}