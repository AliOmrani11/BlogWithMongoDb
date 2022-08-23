using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Category.SiteCategory;

public class SiteCategoryHandler : IRequestHandler<SiteCategoryDto , SiteCategoryByIdResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public SiteCategoryHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<SiteCategoryByIdResultDto> Handle(SiteCategoryDto request, CancellationToken cancellationToken)
    {
        var tags = await _db.CategoryRepository.GetAsync(s => s.Slug == request.Slug && s.DeletedDate == null);
        SiteCategoryByIdResultDto result = _mapper.Map<SiteCategoryByIdResultDto>(tags);
        return result;
    }
}