using DotNet_Task.Data;
using DotNet_Task.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var Configuration = builder.Configuration;
    var connectionString = Configuration.GetSection("constr").Value;

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );

    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
    builder.Services.AddScoped<IProductService, ProductService>();


}

var app = builder.Build();
{

    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<AppDbContext>();
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            var LoggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var Logger = LoggerFactory.CreateLogger<Program>(); // Creating a logger for the Program class
            Logger.LogError(ex, ex.Message); // Logging the error
        }
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
