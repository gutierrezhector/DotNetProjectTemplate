using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Users.Application.Factories;
using SaM.Modules.Users.Ports.InBounds;
using SaM.Modules.Users.Ports.OutBounds.Models;
using SaM.Modules.Users.Web.Abstractions;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application;

public class UsersApplication(IUsersRepository usersRepository, IValidator<UserCandidate> userValidator) : IUsersApplication
{
    public async Task<User> GetByIdAsync(int id)
    {
        var user = await usersRepository.GetByIdAsync(id);
        
        return user;
    }

    public async Task<User> CreateAsync(UserCandidate candidate)
    {
        var validationResult = await userValidator.ValidateAsync(candidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var userToCreate = UserFactory.Create(candidate);
        var newUser = await usersRepository.CreateAsync(userToCreate);
        
        return newUser;
    }
}