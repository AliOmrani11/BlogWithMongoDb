using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Tag.AllTag;

public class AllTagHandler : IRequestHandler<AllTagDto , List<AllTagResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public AllTagHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<List<AllTagResultDto>> Handle(AllTagDto request, CancellationToken cancellationToken)
    {
        var tags = await _db.TagRepository.GetAllAsync();
        List<AllTagResultDto> result = _mapper.Map<List<AllTagResultDto>>(tags);
        return result;
    }
}