using MediatR;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.CQRS.Commands.Delete;

public class DeleteExamHandler(
    IExamsRepository examRepository
) : IRequestHandler<DeleteExamCommand>
{
    public async Task Handle(DeleteExamCommand request, CancellationToken cancellationToken)
    {
        await examRepository.DeleteAsync(request.Id);
    }
}