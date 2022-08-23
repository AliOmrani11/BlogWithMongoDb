using Blog.Application.Repository;
using Blog.Application.UnitOfWork;
using Blog.Infrastructure.Repository;

namespace Blog.Infrastructure.UnitofWork;

public class UnitOfWork : IUnitOfWork 
{
    public UnitOfWork()
    {
    }

    private IAuthorRepository? _authorRepository;
    public IAuthorRepository AuthorRepository
    {
        get => _authorRepository ?? (_authorRepository = new AuthorRepository());
    }

    private ITagRepository? _tagRepository;
    public ITagRepository TagRepository
    {
        get => _tagRepository ?? (_tagRepository = new TagRepository());
    }

    private ICategoryRepository? _categoryRepository;
    public ICategoryRepository CategoryRepository 
    {
        get => _categoryRepository ?? (_categoryRepository = new CategoryRepository());
    }
    
    
    private IBlogRepository? _blogRepository;
    public IBlogRepository BlogRepository 
    {
        get => _blogRepository ?? (_blogRepository = new BlogRepository());
    }
    
  
}