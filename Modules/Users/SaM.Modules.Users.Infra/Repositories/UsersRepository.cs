using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Infra.Factories;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.OutBounds.Repositories;

namespace SaM.Modules.Users.Infra.Repositories;

public class UsersRepository(
    SaMDbContext dbContext,
    Mapper<UserDao, IUser> userDaoToUserEntityMapper
) : BaseRepository(dbContext), IUsersRepository
{
    public async Task<IUser> GetByIdAsync(int id)
    {
        var userDao = await GetByIdInternal(id);

        return userDaoToUserEntityMapper.MapNonNullable(userDao);
    }

    public async Task<IUser> CreateAsync(IUser user)
    {
        var newUserDao = UserDaoFactory.Create(user);

        DbContext.Add(newUserDao);
        await SaveChangesAsync();

        user.Id = newUserDao.Id;

        return user;
    }

    public async Task<IUser> UpdateAsync(int id, IUserUpdateCandidate updateCandidate)
    {
        var userDaoToUpdate = await GetByIdInternal(id);

        userDaoToUpdate.UpdateFromCandidate(updateCandidate);

        await SaveChangesAsync();

        return userDaoToUserEntityMapper.MapNonNullable(userDaoToUpdate);
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