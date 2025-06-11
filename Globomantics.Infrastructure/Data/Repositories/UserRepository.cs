using System.Collections;
using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Infrastructure.Data.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly GlobomanticsDbContext Context;

    public UserRepository(GlobomanticsDbContext context)
    {
        this.Context = context;
    }

    public async Task AddAsync(User user)
    {
        var existingUser = await Context.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

        if (existingUser is null)
        {
            var userToAdd = DomainToDataMapping.MapUser(user);

            await Context.Users.AddAsync(userToAdd);
        }
        else
        {
            existingUser.Name = user.Name;

            Context.Users.Update(existingUser);
        }
    }
    public async Task DeleteAsync(User user)
    {
        var existingUser = await Context.Users.FirstOrDefaultAsync(b => b.Id == user.Id);
        if (existingUser is not null)
        {
            Context.Users.Remove(existingUser);
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await Context.Users.Select(x => DataToDomainMapping.MapUser(x)).ToArrayAsync();
    }

    public async Task<User> FindByAsync(string name)
    {
        var user = await Context.Users.SingleAsync(user => user.Name == name);

        return DataToDomainMapping.MapUser(user);
    }

    public async Task<User> GetAsync(Guid id)
    {
        var user = await Context.Users.SingleAsync(user => user.Id == id);

        return DataToDomainMapping.MapUser(user);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}
