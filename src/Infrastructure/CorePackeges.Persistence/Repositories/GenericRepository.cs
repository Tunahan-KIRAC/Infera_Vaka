using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Comman;
using CorePackeges.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid Id)
    {
        return await dbContext.Set<T>().FindAsync(Id);
    }

    public async Task<T> GetByNameAsync(string name)
    {
        var data = await dbContext.Set<T>().FirstOrDefaultAsync(x=> x.Name == name);



        return data;
    }
}
