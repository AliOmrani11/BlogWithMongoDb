using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Category.AllCategory;

public class AllCategoryHandler : IRequestHandler<AllCategoryDto , List<AllCategoryResultDto>>
{ 
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public AllCategoryHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<List<AllCategoryResultDto>> Handle(AllCategoryDto request, CancellationToken cancellationToken)
    {
        var category = await _db.CategoryRepository.GetAllAsync();
        List<AllCategoryResultDto> result = _mapper.Map<List<AllCategoryResultDto>>(category);
        return result;
    }
}