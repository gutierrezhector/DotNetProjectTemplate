using MediatR;
using SaM.Core.Types.Entities.Exams;

namespace SaM.Modules.Exams.Application.CQRS.Queries.GetById;

public class GetByIdQuery (int id) : IRequest<Exam>
{
    public int Id { get; } = id;
}