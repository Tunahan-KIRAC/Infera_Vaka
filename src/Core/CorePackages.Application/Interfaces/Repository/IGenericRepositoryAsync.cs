using CorePackages.Domain.Comman;

namespace CorePackages.Application.Interfaces.Repository;

public interface IGenericRepositoryAsync<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid Id);
    Task<T> GetByNameAsync(string name);
    Task<T> AddAsync(T entity);
}
