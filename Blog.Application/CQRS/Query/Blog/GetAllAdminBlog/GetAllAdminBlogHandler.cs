using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetAllAdminBlog;

public class GetAllAdminBlogHandler : IRequestHandler<GetAllAdminBlogDto , List<GetAllAdminBlogResultDto>>
{
    
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public GetAllAdminBlogHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<List<GetAllAdminBlogResultDto>> Handle(GetAllAdminBlogDto request, CancellationToken cancellationToken)
    {
        var category = await _db.BlogRepository.GetAllAsync();
        List<GetAllAdminBlogResultDto> result = _mapper.Map<List<GetAllAdminBlogResultDto>>(category);
        return result;
    }
}