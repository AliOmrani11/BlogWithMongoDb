using AutoMapper;
using Blog.Application.UnitOfWork;
using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Tag.SiteAllTag;

public class SiteAllTagHandler : IRequestHandler<SiteAllTagDto , List<SiteTagResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public SiteAllTagHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<SiteTagResultDto>> Handle(SiteAllTagDto request, CancellationToken cancellationToken)
    {
        var tags = await _db.TagRepository.GetAllAsync();
        List<SiteTagResultDto> result = _mapper.Map<List<SiteTagResultDto>>(tags);
        return result;
    }
}