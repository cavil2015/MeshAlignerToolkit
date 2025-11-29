using MeshAligner.Core;
using System.Collections.Generic;
using System.Linq;

namespace MeshAligner.Infrastructure {
    public class Repository {
        private readonly MeshDbContext _context;
        public Repository(MeshDbContext context) => _context = context;
        public List<Mesh> GetAllMeshes() => _context.Meshes.ToList();
    }
}
