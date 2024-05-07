using CorePackages.Domain.Comman;
using System.Linq.Expressions;

namespace CorePackages.Application.Interfaces.Repository;

public interface IGenericRepositoryAsync<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdAsync(Guid Id);
    Task<T> GetByIdAsync(Guid Id, params Expression<Func<T, object>>[] includes);
    Task<T> AddAsync(T entity);
}
