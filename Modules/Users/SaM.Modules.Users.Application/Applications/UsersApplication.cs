using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Users;
using SaM.Modules.Users.Domain.Factories;
using SaM.Modules.Users.Ports.InBounds.Applications;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Payloads;
using SaM.Modules.Users.Ports.OutBounds.Repositories;

namespace SaM.Modules.Users.Application.Applications;

public class UsersApplication(
    IUsersRepository usersRepository,
    UserEntityFactory userEntityFactory,
    IValidator<IUserCreationCandidate> userCreationCandidateValidator,
    IValidator<IUserUpdateCandidate> userUpdateCandidateValidator,
    Mapper<IUserCreationPayload, IUserCreationCandidate> userCreationCandidateMapper,
    Mapper<IUserUpdatePayload, IUserUpdateCandidate> userUpdateCandidateMapper
) : IUsersApplication
{
    public async Task<User> GetByIdAsync(int id)
    {
        return await usersRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(IUserCreationPayload creationPayload)
    {
        var creationCandidate = userCreationCandidateMapper.MapNonNullable(creationPayload);
        var validationResult = await userCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var userToCreate = userEntityFactory.CreateFromCandidate(creationCandidate);
        return await usersRepository.CreateAsync(userToCreate);
    }

    public async Task<User> UpdateAsync(int id, IUserUpdatePayload updatePayload)
    {
        var updateCandidate = userUpdateCandidateMapper.MapNonNullable(updatePayload);
        var validationResult = await userUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        return await usersRepository.UpdateAsync(id, updateCandidate);
    }

    public async Task DeleteAsync(int id)
    {
        await usersRepository.DeleteAsync(id);
    }
}