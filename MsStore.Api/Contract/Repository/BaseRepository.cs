
using Microsoft.EntityFrameworkCore;
using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
{
    public readonly SQLContext _dbContext;

    //// PostgreSql Connection
    //protected readonly NpgsqlConnection _dapperConnection;

    //// SqlServer Connection
    //protected readonly SqlConnection _dapperConnection;

    //public BaseRepository(CleanContext dbContext, DapperContext dapperContext)
    //{
    //    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    //    _dapperConnection = dapperContext._sqlConnection;
    //}

    public BaseRepository(SQLContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    protected IQueryable<T> GetDBSetQuery()
    {
        return _dbContext.Set<T>().AsNoTracking().Where(a => a.IsDeleted == false);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public IReadOnlyList<T> GetAll()
    {
        return _dbContext.Set<T>().Where(a => a.IsDeleted == false).ToList();
    }
    public virtual T GetById(object id)
    {
        return _dbContext.Set<T>().Find(id);
    }
    public virtual async Task<T> GetByIdAsync(object id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> AddRangeAsync(List<T> entities)
    {
        _dbContext.Set<T>().AddRange(entities);
        await _dbContext.SaveChangesAsync();
        return entities;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }
}