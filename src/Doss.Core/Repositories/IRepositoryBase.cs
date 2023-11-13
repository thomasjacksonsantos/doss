using System.Linq.Expressions;

namespace Doss.Core.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> ReturnByIdAsync(Guid id);
    Task<T> SqlSingleAsync<T>(string sql, dynamic param);
    Task<IEnumerable<TEntity>> SqlListAsync(string sql, object param);
    Task<TEntity> ReturnAsNoTrackingAsync(Guid id);
    Task<IEnumerable<TEntity>> ReturnAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string? includeProperties = null);
    Task<IEnumerable<TEntity>> ReturnAllAsync();
    Task<TEntity> ReturnFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null);
    Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> RemoveAsync(Guid id);
    Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> ExistsAsync(Guid id);
    Task SaveAsync();
}