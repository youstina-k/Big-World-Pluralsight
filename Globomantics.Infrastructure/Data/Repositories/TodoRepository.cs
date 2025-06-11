using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Infrastructure.Data.Repositories;

public abstract class TodoRepository<T> : IRepository<T>
    where T : TodoTask
{
    protected GlobomanticsDbContext Context { get; }
    public TodoRepository(GlobomanticsDbContext context)
    {
        Context = context;
    }

    public abstract Task AddAsync(T item);
    public abstract Task<T> GetAsync(Guid id);
    public abstract Task DeleteAsync(T item);

    public virtual async Task<T> FindByAsync(string title)
    {
        var task = await Context.TodoTasks.SingleAsync(t => t.Title == title);

        return DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, T>(task);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    protected async Task SetParentAsync(Data.Models.Todo toBeAdded, Todo item)
    {
        Data.Models.TodoTask? existingParent = null;
        if(item.Parent is not null)
        {
            existingParent = await Context.TodoTasks.FirstOrDefaultAsync(i => i.Id == item.Parent.Id);
        }

        if(existingParent is not null)
        {
            toBeAdded.Parent = existingParent;
        }
        else if (item.Parent is not null)
        {
            var parentToAdd =DomainToDataMapping.MapTodoFromDomain<TodoTask, Data.Models.TodoTask>(item.Parent);
            toBeAdded.Parent = parentToAdd;
            await Context.TodoTasks.AddAsync(parentToAdd);
        }
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        IQueryable<Data.Models.TodoTask> query = Context.TodoTasks.Where(t => !t.IsDeleted)
       .Include(t => t.CreatedBy).Include(t => t.Parent);
        return await query.Select(x => DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, T>(x))
       .ToArrayAsync();
    }

    
}

