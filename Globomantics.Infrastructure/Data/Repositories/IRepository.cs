using Globomantics.Domain;

namespace Globomantics.Infrastructure.Data.Repositories;

public interface IRepository<T>
{
    Task<T> GetAsync(Guid id);
    Task<T> FindByAsync(string value);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T item);
    Task SaveChangesAsync();
    Task DeleteAsync(T item);
}