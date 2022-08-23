using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

namespace Blog.Presentation.Setting;

public static class SettingRegistration
{
    public static IServiceCollection RegisterSetting(this IServiceCollection services)
    {
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
        });

        services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("Admin-v1", new OpenApiInfo
                {
                    Title = "Blog-Site",
                    Version = "v1",

                });
                option.SwaggerDoc("Site-v1", new OpenApiInfo
                {
                    Title = "Blog-Admin",
                    Version = "v1",

                });
                //-------------------------------------------------------------------------------------------------------------------------
                string fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                option.IncludeXmlComments(filePath);
                //-------------------------------------------------------------------------------------------------------------------------
            });

        services.AddCors(option =>
        {
            option.AddPolicy("policy", config =>
            {
                config.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
            });
        });

        services.AddHttpContextAccessor();
        return services;
    }
}