using System.Linq.Expressions;
using Blog.Application.Repository;
using Blog.Data.Entities;
using MongoDB.Driver;

namespace Blog.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly IMongoCollection<TEntity> Collection;

    public Repository()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("BlogDb");
        Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? condition = null)
    {
        var lists = await Collection.CountDocumentsAsync(condition);
        return lists > 0;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await Collection.InsertOneAsync(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await Collection.DeleteOneAsync(s => s.Id == entity.Id);
    }

    public async Task<List<TEntity>> GetAllAsync(string? sort = null)
    {
        var collection = Collection.Find(s => s.DeletedDate == null);
        if (!string.IsNullOrWhiteSpace(sort))
        {
            collection = collection.Sort(sort);
        }

        return await collection.ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? condition = null)
    {
        var collection = await Collection.FindAsync(condition);
        return await collection.FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? condition = null,
        string? sort = null)
    {
        var collection = await Collection.FindAsync(condition);
        return await collection.ToListAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
       await Collection.ReplaceOneAsync(s => s.Id == entity.Id, entity);
    }
}