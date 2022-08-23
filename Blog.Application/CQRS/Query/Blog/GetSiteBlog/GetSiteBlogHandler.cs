using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetSiteBlog;

public class GetSiteBlogHandler : IRequestHandler<GetSiteBlogDto, GetSiteBlogResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public GetSiteBlogHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<GetSiteBlogResultDto> Handle(GetSiteBlogDto request, CancellationToken cancellationToken)
    {
        var blogs = await _db.BlogRepository.GetWithRelation(s => s.Slug == request.Slug);
        GetSiteBlogResultDto result = _mapper.Map<GetSiteBlogResultDto>(blogs);
        return result;
    }
}