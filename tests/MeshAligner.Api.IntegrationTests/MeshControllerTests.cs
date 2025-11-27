using MeshAligner.Api.Controllers;
using MeshAligner.Core;
using MeshAligner.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MeshAligner.Api.IntegrationTests;
public class MeshControllerTests
{
    private MeshController GetController()
    {
        var options = new DbContextOptionsBuilder<MeshDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var db = new MeshDbContext(options);
        var repo = new MeshRepository(db);
        return new MeshController(repo);
    }

    [Fact]
    public async Task CreateAndGet_ShouldReturnMesh()
    {
        var controller = GetController();
        var mesh = new Mesh { Name = ""IntegrationTest"" };
        var createResult = await controller.Create(mesh) as CreatedAtActionResult;
        Assert.NotNull(createResult);
        var id = ((Mesh)createResult!.Value!).Id;
        var getResult = await controller.Get(id) as OkObjectResult;
        var returned = getResult!.Value as Mesh;
        Assert.Equal(""IntegrationTest"", returned!.Name);
    }
}
