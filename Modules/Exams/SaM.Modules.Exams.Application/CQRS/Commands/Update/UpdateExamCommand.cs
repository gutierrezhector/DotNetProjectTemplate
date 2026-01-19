using MediatR;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Application.CQRS.Commands.Update;

public class UpdateExamCommand(int id, IExamUpdatePayload updatePayload) : IRequest<Exam>
{
    public int Id  { get; } = id;
    public IExamUpdatePayload UpdatePayload  { get; } = updatePayload;
}