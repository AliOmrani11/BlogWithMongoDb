using AutoMapper;
using Blog.Application.CQRS.Query.Author.AllAuthor;
using Blog.Application.CQRS.Query.Author.AuthorById;
using Blog.Application.CQRS.Query.Blog.GetAdminBlogById;
using Blog.Application.CQRS.Query.Blog.GetAllAdminBlog;
using Blog.Application.CQRS.Query.Blog.GetSiteBlog;
using Blog.Application.CQRS.Query.Category.AllCategory;
using Blog.Application.CQRS.Query.Category.CategoryById;
using Blog.Application.CQRS.Query.Tag.AllTag;
using Blog.Application.CQRS.Query.Tag.TagById;
using Blog.Data.Entities;
using Blog.Data.Results.Site;

namespace Blog.Application.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Author, AllAuthorResultDto>();
        CreateMap<Author, AuthorByIdResultDto>();
        CreateMap<Data.Entities.Blog, GetAdminBlogByIdResultDto>();
        CreateMap<Data.Entities.Blog, GetAllAdminBlogResultDto>();
        CreateMap<Category, AllCategoryResultDto>();
        CreateMap<Category, CategoryByIdResultDto>();
        CreateMap<Tag, AllTagResultDto>();
        CreateMap<Tag, TagResultDto>();
        CreateMap<Author, SiteAuhtorResultDto>();
        CreateMap<Tag, SiteTagResultDto>();
        CreateMap<Category, SiteCategoryResultDto>();
        CreateMap<BlogLookup, GetSiteAllBlogResultDto>()
            .ForMember(s => s.Author,
                f => f.MapFrom(g => g.Authors.FirstOrDefault()))
            .ForMember(s => s.Category,
                f => f.MapFrom(g => g.Category))
            .ForMember(s => s.Tags,
                f => f.MapFrom(g => g.Tag))
            .ForMember(s => s.Date,
                f => f.MapFrom(g => g.InsertedDate));
        
        CreateMap<BlogLookup, GetSiteBlogResultDto>()
            .ForMember(s => s.Author,
                f => f.MapFrom(g => g.Authors.FirstOrDefault()))
            .ForMember(s => s.Category,
                f => f.MapFrom(g => g.Category))
            .ForMember(s => s.Tags,
                f => f.MapFrom(g => g.Tag))
            .ForMember(s => s.Date,
                f => f.MapFrom(g => g.InsertedDate));
        
        CreateMap<Author,Blog.Application.CQRS.Query.Author.SiteAuthor.SiteAuthorByIdResultDto>();
        CreateMap<Tag, Blog.Application.CQRS.Query.Tag.SiteTag.SiteTagByIdResultDto>();
        CreateMap<Category, Blog.Application.CQRS.Query.Category.SiteCategory.SiteCategoryByIdResultDto>();
    }
}