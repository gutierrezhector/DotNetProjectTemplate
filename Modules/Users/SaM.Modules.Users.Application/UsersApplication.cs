using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Users.Application.Factories;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Ports.InBounds;
using SaM.Modules.Users.Web.Abstractions;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application;

public class UsersApplication(
    IUsersRepository usersRepository, 
    IValidator<UserCreationCandidate> userCreationCandidateValidator,
    IValidator<UserUpdateCandidate> userUpdateCandidateValidator
) : IUsersApplication
{
    public async Task<User> GetByIdAsync(int id)
    {
        return await usersRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(UserCreationCandidate creationCandidate)
    {
        var validationResult = await userCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var userToCreate = UserFactory.Create(creationCandidate);
        var newUser = await usersRepository.CreateAsync(userToCreate);
        
        return newUser;
    }

    public async Task<User> UpdateAsync(int id, UserUpdateCandidate updateCandidate)
    {
        var validationResult = await userUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var user = await usersRepository.GetByIdAsync(id);
        
        user.FirstName = updateCandidate.FirstName;
        user.LastName = updateCandidate.LastName;
        
        return await usersRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        await usersRepository.DeleteAsync(id);
    }
}