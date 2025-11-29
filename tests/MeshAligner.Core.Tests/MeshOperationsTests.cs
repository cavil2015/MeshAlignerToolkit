using Xunit;
using MeshAligner.Core;

namespace MeshAligner.Core.Tests {
    public class MeshOperationsTests {
        [Fact]
        public void Clone_Returns_Copy() {
            var mesh = new Mesh { Id = 1, Name = ""A"" };
            var copy = MeshOperations.Clone(mesh);
            Assert.Equal(mesh.Id, copy.Id);
            Assert.Equal(mesh.Name, copy.Name);
        }
    }
}
