using Xunit;
using MeshAligner.Core;
using System.Collections.Generic;

namespace MeshAligner.Core.Tests
{
    public class UtilitiesTests
    {
        [Fact]
        public void FlattenVertices_ShouldReturnArray()
        {
            var list = new List<int>{1,2,3};
            var arr = Utilities.FlattenVertices(list);
            Assert.Equal(new int[]{1,2,3}, arr);
        }
    }
}
