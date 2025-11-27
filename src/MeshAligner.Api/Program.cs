using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MeshAligner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MeshDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(""DefaultConnection"")));
builder.Services.AddScoped<Repository>();

var app = builder.Build();
app.MapControllers();
app.Run();
