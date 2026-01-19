using MediatR;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.CQRS.Queries.GetById;

public class GetByIdHandler(
    IExamsRepository examRepository
) : IRequestHandler<GetByIdQuery, Exam>
{
    public async Task<Exam> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return await examRepository.GetByIdAsync(request.Id);
    }
}