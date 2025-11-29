using System.Collections.Generic;

namespace MeshAligner.Core {
    public static class MeshOperations {
        public static Mesh Clone(Mesh mesh) {
            return new Mesh { Id = mesh.Id, Name = mesh.Name };
        }
    }
}
