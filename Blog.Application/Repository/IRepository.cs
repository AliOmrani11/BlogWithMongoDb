using System.Linq.Expressions;

namespace Blog.Application.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? condition = null);
    
    Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? condition = null , string? sort = null);
    
    Task<List<TEntity>> GetAllAsync(string? sort = null);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? condition = null);
}