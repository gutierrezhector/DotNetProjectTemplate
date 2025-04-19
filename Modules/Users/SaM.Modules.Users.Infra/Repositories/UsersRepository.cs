using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Data.Daos.Users;
using SaM.Modules.Users.Ports.InBounds;
using SaM.Modules.Users.Ports.OutBounds.Models;

namespace SaM.Modules.Users.Infra.Repositories;

public class UsersRepository(
    SaMDbContext dbContext,
    Mapper<UserDao, User> userMapper
) : IUsersRepository
{
    public async Task<User> GetByIdAsync(int userId)
    {
        var userDao = await dbContext.Set<UserDao>()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (userDao == null)
        {
            throw new NotFoundException($"user with id '{userId}' not found.");
        }

        return userMapper.Map(userDao);
    }

    public async Task<User> CreateAsync(User user)
    {
        dbContext.Add(user);
        await dbContext.SaveChangesAsync();

        return user;
    }
}