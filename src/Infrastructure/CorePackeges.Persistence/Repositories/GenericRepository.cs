using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Comman;
using CorePackeges.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CorePackeges.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
{

    readonly ApplicationDbContext dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        var query = dbContext.Set<T>().AsQueryable();

        // Dinamik olarak ilişkili verileri yükle
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }


    public async Task<T> GetByIdAsync(Guid Id)
    {
        return await dbContext.Set<T>().FindAsync(Id);
    }


    public async Task<T> GetByIdAsync(Guid Id, params Expression<Func<T, object>>[] includes)
    {
        var query = dbContext.Set<T>().AsQueryable();

        // Dinamik olarak ilişkili verileri yükle
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == Id);
    }

}
