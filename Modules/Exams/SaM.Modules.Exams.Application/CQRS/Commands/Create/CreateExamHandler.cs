using FluentValidation;
using MediatR;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Domain.Factories;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Payloads;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.CQRS.Commands.Create;

public class CreateExamHandler(
    IExamsRepository examRepository,
    ExamEntityFactory examEntityFactory,
    IValidator<IExamCreationCandidate> examCreationCandidateValidator,
    Mapper<IExamCreationPayload, IExamCreationCandidate> examCreationPayloadMapper
) : IRequestHandler<CreateExamCommand, Exam>
{
    public async Task<Exam> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var creationCandidate = examCreationPayloadMapper.MapNonNullable(request.CreationPayload);
        var validationResult = await examCreationCandidateValidator.ValidateAsync(creationCandidate, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var examToCreate = examEntityFactory.CreateFromCandidate(creationCandidate);

        return await examRepository.CreateAsync(examToCreate);
    }
}