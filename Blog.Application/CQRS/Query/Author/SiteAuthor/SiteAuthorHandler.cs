using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Author.SiteAuthor;

public class SiteAuthorHandler : IRequestHandler<SiteAuthorDto, SiteAuthorByIdResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public SiteAuthorHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<SiteAuthorByIdResultDto> Handle(SiteAuthorDto request, CancellationToken cancellationToken)
    {
        var category = await _db.AuthorRepository.GetAsync(s => s.Slug == request.Slug && s.DeletedDate == null);
        SiteAuthorByIdResultDto result = _mapper.Map<SiteAuthorByIdResultDto>(category);
        return result;
    }
}