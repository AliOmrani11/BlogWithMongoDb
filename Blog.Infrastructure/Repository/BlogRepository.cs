using System.Linq.Expressions;
using Blog.Application.Repository;
using Blog.Data.Entities;
using MongoDB.Driver;

namespace Blog.Infrastructure.Repository;

public class BlogRepository : Repository<Data.Entities.Blog>, IBlogRepository
{
    public async Task<List<Data.Entities.BlogLookup>> GetAllWithRelation(
        Expression<Func<Data.Entities.BlogLookup, bool>>? condition = null)
    {
        var a = await Collection.Aggregate()
            .Lookup("Tag", "Tags", "_id", "Tag")
            .Lookup("Category", "Categories", "_id", "Category")
            .Lookup("Author", "AuthorId", "_id", "Authors")
            .As<Blog.Data.Entities.BlogLookup>()
            .Match(condition)
            .ToListAsync();

        return a;
    }

    public async Task<BlogLookup> GetWithRelation(Expression<Func<BlogLookup, bool>>? condition = null)
    {
        var a = await Collection.Aggregate()
            .Lookup("Tag", "Tags", "_id", "Tag")
            .Lookup("Category", "Categories", "_id", "Category")
            .Lookup("Author", "AuthorId", "_id", "Authors")
            .As<Blog.Data.Entities.BlogLookup>()
            .Match(condition)
            .FirstOrDefaultAsync();

        return a;
    }
}