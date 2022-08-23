using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Author.AuthorById;

public class AuthorByIdHandler : IRequestHandler<AuthorByIdDto,AuthorByIdResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public AuthorByIdHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<AuthorByIdResultDto> Handle(AuthorByIdDto request, CancellationToken cancellationToken)
    {
        var category = await _db.AuthorRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        AuthorByIdResultDto result = _mapper.Map<AuthorByIdResultDto>(category);
        return result;
    }
}