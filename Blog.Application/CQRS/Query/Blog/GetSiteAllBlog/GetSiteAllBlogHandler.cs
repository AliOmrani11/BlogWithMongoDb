using AutoMapper;
using Blog.Application.UnitOfWork;
using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlog;

public class GetSiteAllBlogHandler : IRequestHandler<GetSiteAllBlogDto , List<GetSiteAllBlogResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public GetSiteAllBlogHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<List<GetSiteAllBlogResultDto>> Handle(GetSiteAllBlogDto request, CancellationToken cancellationToken)
    {
        var blogs = await _db.BlogRepository.GetAllWithRelation(s=>true);
        List<GetSiteAllBlogResultDto> result = _mapper.Map<List<GetSiteAllBlogResultDto>>(blogs);
        return result;
    }
}