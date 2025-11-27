using Microsoft.EntityFrameworkCore;
using MeshAligner.Core;

namespace MeshAligner.Infrastructure
{
    public class MeshDbContext : DbContext
    {
        public MeshDbContext(DbContextOptions<MeshDbContext> options) : base(options) {}
        public DbSet<Mesh> Meshes { get; set; }
    }
}
