using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaM.Modules.Exams.Application.CQRS.Commands.Create;
using SaM.Modules.Exams.Application.CQRS.Commands.Delete;
using SaM.Modules.Exams.Application.CQRS.Commands.Update;
using SaM.Modules.Exams.Application.CQRS.Queries.GetAll;
using SaM.Modules.Exams.Application.CQRS.Queries.GetById;
using SaM.Modules.Exams.Web.Factories;
using SaM.Modules.Exams.Web.Payloads;

namespace SaM.Modules.Exams.Web.Controllers;

[ApiController]
[Route("api/exams")]
public class ExamsController(
    ExamViewModelFactory examViewModelFactory,
    IMediator mediator
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var command = new GetAllQuery();
        var exams = await mediator.Send(command);

        return Ok(examViewModelFactory.CreateFromEntity(exams));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var command = new GetByIdQuery(id);
        var exam = await mediator.Send(command);

        return Ok(examViewModelFactory.CreateFromEntity(exam));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ExamCreationPayload creationPayload)
    {
        var command = new CreateExamCommand(creationPayload);
        var newExam = await mediator.Send(command);

        return Created($"exams/{newExam.Id}", newExam);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExamUpdatePayload updatePayload)
    {
        var command = new UpdateExamCommand(id, updatePayload);
        var updatedExam = await mediator.Send(command);

        return Ok(examViewModelFactory.CreateFromEntity(updatedExam));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var command = new DeleteExamCommand(id);
        await mediator.Send(command);

        return NoContent();
    }
}