using MediatR;

namespace SaM.Modules.Exams.Application.CQRS.Commands.Delete;

public class DeleteExamCommand(int id) : IRequest
{
    public int Id { get; } = id;
}