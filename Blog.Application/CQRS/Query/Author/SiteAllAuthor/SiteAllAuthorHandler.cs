using AutoMapper;
using Blog.Application.UnitOfWork;
using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Author.SiteAllAuthor;

public class SiteAllAuthorHandler : IRequestHandler<SiteAllAuthorDto, List<SiteAuhtorResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public SiteAllAuthorHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<SiteAuhtorResultDto>> Handle(SiteAllAuthorDto request, CancellationToken cancellationToken)
    {
        var authors = await _db.AuthorRepository.GetAllAsync();
        List<SiteAuhtorResultDto> result = _mapper.Map<List<SiteAuhtorResultDto>>(authors);
        return result;
    }
}