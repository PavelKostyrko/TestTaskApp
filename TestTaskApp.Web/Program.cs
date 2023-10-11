using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TestTaskApp.Data;
using TestTaskApp.Logic.AuxiliaryÑlasses;
using TestTaskApp.Logic.AuxiliaryÑlasses.Interfaces;
using TestTaskApp.Logic.Models;
using TestTaskApp.Logic.Services;
using TestTaskApp.Logic.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "TestTaskApp API",
        Description = "The ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Pavel Kostyrko",
            Email = "mr_pablo@mail.ru",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "My License",
            Url = new Uri("https://example.com/license")
        }
    });

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var connectionString = builder.Configuration.GetValue<string>("TestTaskAppConnection");

builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IValidator<UserDto>, Validator<UserDto>>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "TestTaskApp API V1.0");
    options.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "TestTaskApp");

app.Run();
