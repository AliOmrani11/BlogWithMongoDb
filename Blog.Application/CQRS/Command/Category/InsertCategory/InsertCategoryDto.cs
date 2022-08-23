﻿using Blog.Data.Results;
using MediatR;

namespace Blog.Application.CQRS.Command.Category.InsertCategory;

public class InsertCategoryDto : IRequest<ServiceResult<string>>
{
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public bool Index { get; set; }
    public string? Header { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}