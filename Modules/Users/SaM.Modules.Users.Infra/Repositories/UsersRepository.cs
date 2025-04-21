using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Infra.Factories;
using SaM.Modules.Users.Ports.InBounds;

namespace SaM.Modules.Users.Infra.Repositories;

public class UsersRepository(
    SaMDbContext dbContext,
    Mapper<UserDao, User> userMapper
) : BaseRepository(dbContext), IUsersRepository
{
    public async Task<User> GetByIdAsync(int id)
    {
        var userDao = await GetByIdInternal(id);
        
        return userMapper.Map(userDao);
    }

    public async Task<User> CreateAsync(User user)
    {
        var newUserDao = UserDaoFactory.Create(user);
        
        DbContext.Add(newUserDao);
        await SaveChangesAsync();

        user.Id = newUserDao.Id;
        
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var userDaoToUpdate = await GetByIdInternal(user.Id);
        
        userDaoToUpdate.UpdateFromDomainEntity(user);
        
        await SaveChangesAsync();

        return user;
    }

    public async Task DeleteAsync(int id)
    {
        var userDao = await GetByIdInternal(id);

        Set<UserDao>().Remove(userDao);
        
        await SaveChangesAsync();
    }

    private async Task<UserDao> GetByIdInternal(int id)
    {
        var userDao = await Set<UserDao>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (userDao == null)
        {
            throw new NotFoundException($"user with id '{id}' not found.");
        }

        return userDao;
    }
}