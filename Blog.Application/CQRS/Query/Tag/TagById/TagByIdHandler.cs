using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Tag.TagById;

public class TagByIdHandler : IRequestHandler<TagByIdDto , TagResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public TagByIdHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<TagResultDto> Handle(TagByIdDto request, CancellationToken cancellationToken)
    {
        var tag = await _db.TagRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        TagResultDto result = _mapper.Map<TagResultDto>(tag);
        return result;
    }
}