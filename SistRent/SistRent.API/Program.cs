using Microsoft.EntityFrameworkCore;
using SistRent.Application;
using SistRent.Infrastructure;
using SistRent.Infrastructure.DataBase;
using SistRent.Infrastructure.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//builder.Services.AddDbContext<AppDBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))
//);
builder.Services.AddInfrasEstructureServices(builder.Configuration).AddApplicationServices();

builder.Services.Configure<FileStorageOptions>(options=>
{
    builder.Configuration.GetSection("FileStorageOptions").Bind(options);
    options.BaseUrl = builder.Environment.WebRootPath;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
