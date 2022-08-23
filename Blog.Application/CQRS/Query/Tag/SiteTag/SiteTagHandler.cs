using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Tag.SiteTag;

public class SiteTagHandler : IRequestHandler<SiteTagDto, SiteTagByIdResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public SiteTagHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<SiteTagByIdResultDto> Handle(SiteTagDto request, CancellationToken cancellationToken)
    {
        var tags = await _db.TagRepository.GetAsync(s => s.Slug == request.Slug && s.DeletedDate == null);
        SiteTagByIdResultDto result = _mapper.Map<SiteTagByIdResultDto>(tags);
        return result;
    }
}