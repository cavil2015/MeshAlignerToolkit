using Xunit;
using Microsoft.EntityFrameworkCore;
using MeshAligner.Infrastructure;
using MeshAligner.Core;
using System.Threading.Tasks;

namespace MeshAligner.Infrastructure.Tests
{
    public class RepositoryTests
    {
        private Repository GetRepo()
        {
            var options = new DbContextOptionsBuilder<MeshDbContext>()
                .UseInMemoryDatabase(databaseName: ""TestDb"")
                .Options;
            var context = new MeshDbContext(options);
            return new Repository(context);
        }

        [Fact]
        public async Task AddMeshAsync_ShouldAddMesh()
        {
            var repo = GetRepo();
            var mesh = new Mesh { Name=""Test"" };
            var result = await repo.AddMeshAsync(mesh);
            Assert.Equal(mesh.Name, result.Name);
        }
    }
}
