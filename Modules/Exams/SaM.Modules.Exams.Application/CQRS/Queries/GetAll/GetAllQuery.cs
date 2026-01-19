using MediatR;
using SaM.Core.Types.Entities.Exams;

namespace SaM.Modules.Exams.Application.CQRS.Queries.GetAll;

public class GetAllQuery  : IRequest<List<Exam>>
{
}