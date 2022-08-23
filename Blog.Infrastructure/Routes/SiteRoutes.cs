namespace Blog.Infrastructure.Routes;

public static class SiteRoutes
{
    private const string BaseUrl = "api/blog/site/v{version:apiversion}/";

    public static class Blog
    {
        public const string AllBlog = BaseUrl + "post/get";
        public const string AllBlogByTag = BaseUrl + "post/get-tag/{Slug}";
        public const string AllBlogByCategory = BaseUrl + "post/get-category/{Slug}";
        public const string AllBlogByAuthor = BaseUrl + "post/get-author/{Slug}";
        public const string GetBlog = BaseUrl + "post/get/{Slug}";
    }
    
    public static class Author
    {
        public const string AllAuthor = BaseUrl + "author/get";
        public const string AuthorBySlug = BaseUrl + "author/get/{Slug}";
    }
    
    public static class Category
    {
        public const string AllCategory = BaseUrl + "category/get";
        public const string CategoryBySlug = BaseUrl + "category/get-{Slug}";
    }
    
    public static class Tag
    {
        public const string AllTag = BaseUrl + "tag/get";
        public const string TagBySlug = BaseUrl + "tag/get-{Slug}";
    }
}