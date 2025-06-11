using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Infrastructure.Data.Repositories;

public class TodoTaskRepository : TodoRepository<TodoTask>
{
    public TodoTaskRepository(GlobomanticsDbContext context) : base(context)
    {
    }

    public override async Task AddAsync(TodoTask todoTask)
    {
        var todoTaskToAdd = DomainToDataMapping.MapTodoFromDomain<TodoTask, Models.TodoTask>(todoTask);

        await Context.TodoTasks.AddAsync(todoTaskToAdd);
    }

    public override async Task<TodoTask> GetAsync(Guid id)
    {
        var data = await Context.TodoTasks.SingleAsync(bug => bug.Id == id);

        return DataToDomainMapping.MapTodoFromData<Models.TodoTask, TodoTask>(data);
    }
    public override async Task DeleteAsync(TodoTask task)
    {
        var existingTask = await Context.TodoTasks.FirstOrDefaultAsync(b => b.Id == task.Id);
        if (existingTask is not null)
        {
            Context.TodoTasks.Remove(existingTask);
            await Context.SaveChangesAsync();
        }
    }
}
