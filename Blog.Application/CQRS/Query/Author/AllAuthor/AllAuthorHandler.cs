using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Author.AllAuthor;

public class AllAuthorHandler : IRequestHandler<AllAuthorDto,List<AllAuthorResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public AllAuthorHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<AllAuthorResultDto>> Handle(AllAuthorDto request, CancellationToken cancellationToken)
    {
        var authors = await _db.AuthorRepository.GetAllAsync();
        List<AllAuthorResultDto> result = _mapper.Map<List<AllAuthorResultDto>>(authors);
        return result;
    }
}