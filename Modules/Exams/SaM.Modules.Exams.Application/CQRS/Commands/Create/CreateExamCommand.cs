using MediatR;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Application.CQRS.Commands.Create;

public class CreateExamCommand(IExamCreationPayload creationPayload) : IRequest<Exam>
{
    public IExamCreationPayload CreationPayload  { get; } = creationPayload;
}