using AutoMapper;
using Blog.Application.UnitOfWork;
using Blog.Data.Results.Site;
using MediatR;

namespace Blog.Application.CQRS.Query.Category.SiteAllCategory;

public class SiteAllCategoryHandler : IRequestHandler<SiteAllCategoryDto , List<SiteCategoryResultDto>>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public SiteAllCategoryHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
    public async Task<List<SiteCategoryResultDto>> Handle(SiteAllCategoryDto request, CancellationToken cancellationToken)
    {
        var category = await _db.CategoryRepository.GetAllAsync();
        List<SiteCategoryResultDto> result = _mapper.Map<List<SiteCategoryResultDto>>(category);
        return result;
    }
}