using MediatR;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.CQRS.Queries.GetAll;

public class GetAllHandler(
    IExamsRepository examRepository
) : IRequestHandler<GetAllQuery, List<Exam>>
{
    public async Task<List<Exam>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await examRepository.GetAllAsync();
    }
}