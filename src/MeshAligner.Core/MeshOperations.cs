using System.Collections.Generic;

namespace MeshAligner.Core
{
    public static class MeshOperations
    {
        public static Mesh Translate(Mesh mesh, int offset)
        {
            var newMesh = new Mesh
            {
                Id = mesh.Id,
                Name = mesh.Name,
                Vertices = mesh.Vertices.ConvertAll(v => v + offset),
                Triangles = new List<int>(mesh.Triangles)
            };
            return newMesh;
        }

        public static Mesh Scale(Mesh mesh, double factor)
        {
            var newMesh = new Mesh
            {
                Id = mesh.Id,
                Name = mesh.Name,
                Vertices = mesh.Vertices.ConvertAll(v => (int)(v * factor)),
                Triangles = new List<int>(mesh.Triangles)
            };
            return newMesh;
        }
    }
}
