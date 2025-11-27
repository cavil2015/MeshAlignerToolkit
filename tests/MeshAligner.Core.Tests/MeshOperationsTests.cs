using Xunit;
using MeshAligner.Core;
using System.Collections.Generic;

namespace MeshAligner.Core.Tests
{
    public class MeshOperationsTests
    {
        [Fact]
        public void Translate_ShouldMoveVertices()
        {
            var mesh = new Mesh { Vertices = new List<int>{1,2,3} };
            var result = MeshOperations.Translate(mesh, 5);
            Assert.Equal(new List<int>{6,7,8}, result.Vertices);
        }
    }
}
