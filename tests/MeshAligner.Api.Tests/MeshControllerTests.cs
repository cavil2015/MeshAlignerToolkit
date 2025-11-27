using Xunit;
using Microsoft.AspNetCore.Mvc;
using MeshAligner.Api.Controllers;
using MeshAligner.Infrastructure;
using MeshAligner.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeshAligner.Api.Tests
{
    public class MeshControllerTests
    {
        private MeshController GetController()
        {
            var options = new DbContextOptionsBuilder<MeshDbContext>()
                .UseInMemoryDatabase(databaseName: ""ApiTestDb"")
                .Options;
            var context = new MeshDbContext(options);
            var repo = new Repository(context);
            return new MeshController(repo);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedMesh()
        {
            var controller = GetController();
            var mesh = new Mesh { Name=""API Test"" };
            var result = await controller.Create(mesh) as CreatedAtActionResult;
            Assert.NotNull(result);
            var created = result.Value as Mesh;
            Assert.Equal(mesh.Name, created.Name);
        }
    }
}
