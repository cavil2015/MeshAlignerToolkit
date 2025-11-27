using Xunit;
using MeshAligner.Core;
using System;

namespace MeshAligner.Core.Tests
{
    public class MeshTests
    {
        [Fact]
        public void CreateMesh_ShouldHaveId()
        {
            var mesh = new Mesh();
            Assert.NotEqual(Guid.Empty, mesh.Id);
        }
    }
}
