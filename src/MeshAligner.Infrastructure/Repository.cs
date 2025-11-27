using MeshAligner.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeshAligner.Infrastructure
{
    public class Repository
    {
        private readonly MeshDbContext _context;
        public Repository(MeshDbContext context) { _context = context; }

        public async Task<Mesh> AddMeshAsync(Mesh mesh)
        {
            _context.Meshes.Add(mesh);
            await _context.SaveChangesAsync();
            return mesh;
        }
    }
}
