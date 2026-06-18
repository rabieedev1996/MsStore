
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Interface;

public interface IBaseRepository<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> GetAllAsync();
    IReadOnlyList<T> GetAll();
    T GetById(object id);
    Task<T> GetByIdAsync(object id);
    Task<T> AddAsync(T entity);
    Task<List<T>> AddRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(List<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(List<T> entities);
}