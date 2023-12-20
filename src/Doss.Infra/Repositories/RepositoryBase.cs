using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Doss.Core.Interfaces.Repositories;
using Doss.Infra.Data;
using Dapper;

namespace Doss.Infra.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly DossDbContext Context;
    protected readonly SqlConnection? Connection;

    public RepositoryBase(DossDbContext context)
    {
        Context = context;
        Connection = context.Database.GetDbConnection() as SqlConnection;
    }

    public async Task<T> AddAsync(T entity, bool saveChanges = true)
    {
        await Context.AddAsync<T>(entity);

        if (saveChanges)
            await Context.SaveChangesAsync();

        return entity;
    }

    public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task ExecuteAsync(string sql, object param)
        => await Connection.ExecuteAsync(sql, param: param);

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> ReturnAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
    {
        IQueryable<T> query = Context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            Parallel.ForEach(includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), (includeProperty) =>
            {
                query = query.Include(includeProperty);
            });
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> ReturnAllAsync()
        => await Context.Set<T>().ToListAsync();

    public Task<T> ReturnAsNoTrackingAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<T> ReturnByFilterAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = Context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            Parallel.ForEach(includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), (includeProperty) =>
            {
                query = query.Include(includeProperty);
            });
        }

        return await query.FirstOrDefaultAsync() ?? null!;
    }

    public virtual async Task<T> ReturnByIdAsync(Guid id)
      => await Context.Set<T>().FindAsync(id) ?? null!;

    public Task<T> ReturnFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync()
        => await Context.SaveChangesAsync();

    public async Task<IEnumerable<T>> SqlListAsync(string sql, object param)
    {
        return await Connection.QueryAsync<T>(sql, param: param);
    }

    public async Task<TParam> SqlSingleAsync<TParam>(string sql, object param)
    {
        return (await Connection.QueryAsync<TParam>(sql, param: param))
                .FirstOrDefault();
    }

    public Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}