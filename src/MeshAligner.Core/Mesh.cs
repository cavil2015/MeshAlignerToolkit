using System;
using System.Collections.Generic;

namespace MeshAligner.Core
{
    public class Mesh
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public List<int> Vertices { get; set; } = new List<int>();
        public List<int> Triangles { get; set; } = new List<int>();
    }
}
