using FluentValidation;
using MediatR;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Domain.Validators;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Payloads;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.CQRS.Commands.Update;

public class UpdateExamHandler(
    IExamsRepository examRepository,
    IValidator<ExamUpdateWrapper> examUpdateCandidateValidator,
    Mapper<IExamUpdatePayload, IExamUpdateCandidate> examUpdatePayloadMapper
) : IRequestHandler<UpdateExamCommand, Exam>
{
    public async Task<Exam> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
    {
        var updateCandidate = examUpdatePayloadMapper.MapNonNullable(request.UpdatePayload);
        var currentExam = await examRepository.GetByIdAsync(request.Id);
        var validationResult =
            await examUpdateCandidateValidator.ValidateAsync(new ExamUpdateWrapper(updateCandidate, currentExam), cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        return await examRepository.UpdateAsync(request.Id, updateCandidate);
    }
}