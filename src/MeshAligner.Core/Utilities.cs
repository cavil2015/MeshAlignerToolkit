using System.Collections.Generic;

namespace MeshAligner.Core
{
    public static class Utilities
    {
        public static int[] FlattenVertices(List<int> vertices)
        {
            return vertices.ToArray();
        }
    }
}
