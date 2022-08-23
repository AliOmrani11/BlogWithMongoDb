namespace Blog.Infrastructure.Routes;

public static class AdminRoutes
{
    private const string BaseUrl = "api/blog/admin/v{version:apiversion}/";

    public static class Tag
    {
        public const string Insert = BaseUrl + "tag/insert";
        public const string Update = BaseUrl + "tag/update";
        public const string Delete = BaseUrl + "tag/delete/{Id}";
        public const string GetAll = BaseUrl + "tag/get";
        public const string Get = BaseUrl + "tag/get/{Id}";
    }

    public static class Category
    {
        public const string Insert = BaseUrl + "category/insert";
        public const string Update = BaseUrl + "category/update";
        public const string Delete = BaseUrl + "category/delete/{Id}";
        public const string GetAll = BaseUrl + "category/get";
        public const string Get = BaseUrl + "category/get/{Id}";
    }

    public static class Author
    {
        public const string Insert = BaseUrl + "author/insert";
        public const string Update = BaseUrl + "author/update";
        public const string Delete = BaseUrl + "author/delete/{Id}";
        public const string GetAll = BaseUrl + "author/get";
        public const string Get = BaseUrl + "author/get/{Id}";
    }

    public static class Blog
    {
        public const string Insert = BaseUrl + "blog/insert";
        public const string Update = BaseUrl + "blog/update";
        public const string Delete = BaseUrl + "blog/delete/{Id}";
        public const string GetAll = BaseUrl + "blog/get";
        public const string Get = BaseUrl + "blog/get/{Id}";
    }
}