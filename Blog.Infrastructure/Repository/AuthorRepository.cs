using Blog.Application.Repository;
using Blog.Data.Entities;

namespace Blog.Infrastructure.Repository;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
}