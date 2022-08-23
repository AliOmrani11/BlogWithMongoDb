using AutoMapper;
using Blog.Application.UnitOfWork;
using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteAllBlogByTag;

public class GetSiteAllBlogByTagHandler : IRequestHandler<GetSiteAllBlogByTagDto, List<GetSiteAllBlogResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public GetSiteAllBlogByTagHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<List<GetSiteAllBlogResultDto>> Handle(GetSiteAllBlogByTagDto request,
        CancellationToken cancellationToken)
    {
        var blogs = await _db.BlogRepository.GetAllWithRelation(s => 
            s.Tag != null && s.Tag.Any(f => f.Slug == request.Slug));
        List<GetSiteAllBlogResultDto> result = _mapper.Map<List<GetSiteAllBlogResultDto>>(blogs);
        return result;
    }
}