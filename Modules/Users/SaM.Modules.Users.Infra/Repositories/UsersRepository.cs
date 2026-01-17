using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Students;
using SaM.Database.Core.Daos.Teachers;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Domain.Factories;
using SaM.Modules.Users.Infra.Factories;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.OutBounds.Repositories;

namespace SaM.Modules.Users.Infra.Repositories;

public class UsersRepository(
    SaMDbContext dbContext,
    UserEntityFactory userEntityFactory,
    UserDaoFactory userDaoFactory
) : BaseRepository<UserDao>(dbContext), IUsersRepository
{
    public async Task<User> GetByIdAsync(int id)
    {
        var userDao = await GetByIdInternal(id);

        return userEntityFactory.CreateFromDao(userDao);
    }

    public async Task<User> CreateAsync(User user)
    {
        var newUserDao = userDaoFactory.CreateFromEntity(user);

        DbContext.Add(newUserDao);
        await SaveChangesAsync();

        var userCreatedDao = await GetByIdInternal(newUserDao.Id);
        return userEntityFactory.CreateFromDao(userCreatedDao);
    }

    public async Task<User> UpdateAsync(int id, IUserUpdateCandidate updateCandidate)
    {
        var userDaoToUpdate = await GetByIdInternal(id);

        userDaoFactory.UpdateFromCandidate(userDaoToUpdate, updateCandidate);

        await SaveChangesAsync();

        return userEntityFactory.CreateFromDao(userDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var userDao = await GetByIdInternal(id);

        SetWithoutIncludes().Remove(userDao);

        await SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(int userId)
    {
        return await SetWithoutIncludes()
            .AnyAsync(u => u.Id == userId);
    }

    public async Task<bool> IsUserLinkedToTeacherAsync(int userId)
    {
        return await DbContext.Set<TeacherDao>()
            .AnyAsync(u => u.UserId == userId);
    }

    public async Task<bool> IsUserLinkedToStudentAsync(int userId)
    {
        return await DbContext.Set<StudentDao>()
            .AnyAsync(u => u.UserId == userId);
    }

    private async Task<UserDao> GetByIdInternal(int id)
    {
        var userDao = await SetWithIncludes()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (userDao == null)
        {
            throw new NotFoundException($"user with id '{id}' not found.");
        }

        return userDao;
    }

    protected override IQueryable<UserDao> ApplyIncludes(DbSet<UserDao> set)
    {
        return set;
    }
}