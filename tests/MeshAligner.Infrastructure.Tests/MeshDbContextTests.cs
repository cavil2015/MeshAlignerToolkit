using Xunit;
using MeshAligner.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MeshAligner.Core;

public class MeshDbContextTests
{
    [Fact]
    public void Can_Add_And_Get_Mesh()
    {
        var options = new DbContextOptionsBuilder<MeshDbContext>()
            .UseInMemoryDatabase(""TestDb"").Options;
        using var context = new MeshDbContext(options);
        context.Meshes.Add(new Mesh { Name = ""Test"" });
        context.SaveChanges();
        Assert.Single(context.Meshes);
    }
}
