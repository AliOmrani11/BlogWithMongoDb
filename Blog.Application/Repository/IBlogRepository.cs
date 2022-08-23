using System.Linq.Expressions;

namespace Blog.Application.Repository;

public interface IBlogRepository : IRepository<Data.Entities.Blog>
{
    Task<List<Data.Entities.BlogLookup>> GetAllWithRelation(
        Expression<Func<Data.Entities.BlogLookup, bool>>? condition = null);
    
    Task<Data.Entities.BlogLookup> GetWithRelation(
        Expression<Func<Data.Entities.BlogLookup, bool>>? condition = null);
}