using MediatR;

namespace Blog.Application.CQRS.Query.Tag.AllTag;

public class AllTagDto : IRequest<List<AllTagResultDto>>
{
    
}