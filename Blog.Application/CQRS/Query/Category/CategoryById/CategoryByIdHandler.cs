using AutoMapper;
using Blog.Application.UnitOfWork;
using MediatR;

namespace Blog.Application.CQRS.Query.Category.CategoryById;

public class CategoryByIdHandler : IRequestHandler<CategoryByIdDto, CategoryByIdResultDto>
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public CategoryByIdHandler(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<CategoryByIdResultDto> Handle(CategoryByIdDto request, CancellationToken cancellationToken)
    {
        var category = await _db.CategoryRepository.GetAsync(s => s.Id == request.Id && s.DeletedDate == null);
        CategoryByIdResultDto result = _mapper.Map<CategoryByIdResultDto>(category);
        return result;
    }
}