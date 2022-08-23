using Blog.Application.ServiceRegister;
using Blog.Infrastructure.ServiceRegistration;
using Blog.Presentation.Setting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterApplication();
builder.Services.RegisterInfrastructure();
builder.Services.RegisterSetting();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/Site-v1/swagger.json", "Site-v1");
        config.SwaggerEndpoint("/swagger/Admin-v1/swagger.json", "Admin-v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();