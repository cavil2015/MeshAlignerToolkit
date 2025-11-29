using Xunit;
using MeshAligner.Core;

namespace MeshAligner.Core.Tests {
    public class MeshTests {
        [Fact]
        public void Mesh_Creation_Works() {
            var mesh = new Mesh { Id = 1, Name = ""Test"" };
            Assert.Equal(1, mesh.Id);
        }
    }
}
