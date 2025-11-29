using Microsoft.EntityFrameworkCore;
using MeshAligner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MeshDbContext>(options => 
    options.UseInMemoryDatabase(""MeshDb""));
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
