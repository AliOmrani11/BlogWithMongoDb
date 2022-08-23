using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Blog.GetAdminBlogById;

public class GetAdminBlogByIdHandler : IRequestHandler<GetAdminBlogByIdDto , GetAdminBlogByIdResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public GetAdminBlogByIdHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<GetAdminBlogByIdResultDto> Handle(GetAdminBlogByIdDto request, CancellationToken cancellationToken)
    {
        var category = await _db.BlogRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        GetAdminBlogByIdResultDto result = _mapper.Map<GetAdminBlogByIdResultDto>(category);
        return result;
    }
}