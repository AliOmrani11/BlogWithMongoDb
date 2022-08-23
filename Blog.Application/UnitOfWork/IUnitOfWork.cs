using Blog.Application.Repository;

namespace Blog.Application.UnitOfWork;

public interface IUnitOfWork
{
    IAuthorRepository? AuthorRepository { get; }
    ITagRepository? TagRepository { get; }
    ICategoryRepository? CategoryRepository { get; }
    IBlogRepository? BlogRepository { get; }
}